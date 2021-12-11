using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GatheringField
    {
        public Vector2[,] FieldArray { get; set; }

        public int Resolution { get; set; }

        public int Row { get; }

        public int Column { get; }

        public GatheringField(int height, int width)
        {
            Resolution = 10;

            int row = height / Resolution;

            int column = width / Resolution;

            Row = row;

            Column = column;

            FieldArray = new Vector2[row, column];

            int[] directions = new int[3];

            directions[0] = -1;

            directions[1] = 0;

            directions[2] = 1;

            //for (int i = 0; i < column; i++) 
            //{

            //   FieldArray[0, 1] = new Vector(1, 0);

            // }

            for (int i = 0; i < row; i++)
            {

                //FieldArray[i, 0] = new Vector(0, 1); 

                for (int j = 0; j < column; j++)
                {
                    Random random = new Random();

                    int r1 = random.Next(3);

                    int r2 = random.Next(3);

                    FieldArray[i, j] = new Vector2(directions[r1], directions[r2]);

                    /*FieldArray[i, j] = new Vector(-1, 0);

                    if (j % 8 == 0 || j % 17 == 0 || j % 13 == 0)
                    {

                        FieldArray[i, j] = new Vector(1, 0);

                    }
                    else if (j % 6 == 0 || j % 37 ==0 || j % 41==0)
                    {

                        FieldArray[i, j] = new Vector(0, 1);

                    }
                    else if (j % 5 == 0  || j % 23==0 || j % 29==0)
                    {

                        FieldArray[i, j] = new Vector(1, 0);

                    }
                    else if (j % 7 == 0)
                    {

                        FieldArray[i, j] = new Vector(-1, 0);

                    }
                    else if (j % 11 == 0)
                    {

                        FieldArray[i, j] = new Vector(0, -1);

                    }
                    else if (j % 3 == 0) {
                        
                        FieldArray[i, j] = new Vector(-1, -1);
                    
                    }*/


                }


            }


        }

        public Vector2 Lookup(Vector2 lookup) 
        {

            int row = (int)lookup.Y / Resolution;

            int column = (int)lookup.X / Resolution;

            /*if (row >= Row) {

                while (row >= Row) {

                    row -= 1;

                }
            
            }
            if (column >= Column) {

                while (column>= Column) {

                    column -= 1;
                
                }
 
            }
            if (row < 0) {

                while (row < 0)
                {

                    row += 1;

                }

            }

            if (column < 0) {

                while (column < 0)
                {

                    column += 1;

                }

            }*/

            Random r1 = new Random();

            row = r1.Next(this.Row - 1);

            column = r1.Next(this.Column - 1);

            Vector2 finalVector = new Vector2((float)FieldArray[row, column].X, (float)FieldArray[row, column].Y);



            return finalVector;


        }
    }
}
