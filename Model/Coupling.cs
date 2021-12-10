﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Coupling : IBehavior
    {
        public IFlocking Performer { get; set; }

        public Coupling(IFlocking performer)
        {
            Performer = performer;
        }

        public void Move()
        {
            Coh();
            Align();
            Separate();
        }

        public void Coh() 
        {
            // neighbordist = 90f;

            Vector2 sum = new Vector2(0, 0);

            int count = 0;

            foreach (IFlocking a in Performer.Actors)
            {

                float dist = Vector2.Distance(Performer.Location, a.Location);

                if ((dist > 0) && (dist < Performer.NeighbourDistance))
                {
                    sum += a.Location;
                    count++;

                }

            }
            if (count > 0)
            {
                sum /= count;

                Vector2 desired = sum;

                desired = Vector2.Normalize(desired);

                desired = desired * Performer.MaxSpeed;

                Vector2 steer = Vector2.Subtract(desired, Performer.Velocity);

                Performer.Acceleration = Performer.Acceleration + steer;

                Performer.Velocity = Performer.Velocity + Performer.Acceleration;

                //velocity.limit(maxspeed);

                Performer.Location = Performer.Location + Performer.Velocity;

                Performer.Acceleration = Performer.Acceleration * 0;

            }

        }

        public void Align() 
        {

            //float neighbordist = 90f;

            int count = 0;

            Vector2 sum = new Vector2();

            foreach (IFlocking a in Performer.Actors)
            {

                float distance = Vector2.Distance(Performer.Location, a.Location);
                if ((distance > 0) && (distance < Performer.NeighbourDistance))
                {

                    sum += a.Velocity;
                    count++;
                }

            }
            if (count > 0)
            {

                sum /= Performer.Actors.Count();

                sum = Vector2.Normalize(sum);

                sum *= Performer.MaxSpeed;

                Vector2 steer = Vector2.Subtract(sum, Performer.Velocity);

                Performer.Acceleration += steer;

                Performer.Velocity += Performer.Acceleration;

                //velocity.limit(maxspeed);

                Performer.Location = Performer.Location + Performer.Velocity;

                Performer.Acceleration = Performer.Acceleration * 0;
            }


        }

        public void Separate() 
        {

            //float desiredseparation = 20f;

            //float desiredseparation = 10 * this.Actor.Width;

            Vector2 sum = new Vector2();

            int count = 0;

            foreach (IFlocking a in Performer.Actors)
            {
                if (a != this)
                {
                    float distance = Vector2.Distance(Performer.Location, a.Location);

                    if ((distance > 0) && (distance < Performer.DesiredSeparation))
                    {
                        Vector2 diff = Vector2.Subtract(Performer.Location, a.Location);
                        diff = Vector2.Normalize(diff);
                        //diff /= distance;
                        sum += diff;
                        count++;
                    }


                }

            }
            if (count > 0)
            {

                sum /= count;

                Vector2 steer = Vector2.Subtract(sum, Performer.Velocity);

                Performer.Acceleration += steer;

                Performer.Velocity += Performer.Acceleration;

                //velocity.limit(maxspeed);

                Performer.Location = Performer.Location + Performer.Velocity;

                Performer.Acceleration = Performer.Acceleration * 0;
            }


        }
    }
}
