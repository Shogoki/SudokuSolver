using System;
namespace Sudoku_Solver
{
    class SudokuField
    {
        private int[,] field;
       

        public SudokuField(System.Windows.Forms.TextBox[,] boxes)
        {
            int width = boxes.GetLength(0);
            int height =boxes.GetLength(1);
            field = new int[width, height];

            for(int x = 0; x < width;x++)
                for (int y = 0; y < height; y++)
                {
                    if (boxes[x, y].Text == "")
                        field[x, y] = 0;
                    else
                    if(!Int32.TryParse(boxes[x,y].Text,out field[x,y]))
                        throw new ArgumentException("Wrong Format in TextBox");
                }

        }

        public int GetValue(int x, int y)
        {
            return field[x, y];
        }

        public void SetField(int x, int y, int val)
        {
            field[x, y] = val;
        }

        public override string ToString()
        {
            return field.ToString();
        }

        public void UpdateField(System.Windows.Forms.TextBox[,] boxes)
        {
            int width = field.GetLength(0);
            int height = field.GetLength(1);
          for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    if (boxes[x, y].Text == "")
                        field[x, y] = 0;
                    else
                    if (!Int32.TryParse(boxes[x, y].Text, out field[x, y]))
                        throw new ArgumentException("Wrong Format in TextBox");
                }
        }
        public void Field2textboxes(ref System.Windows.Forms.TextBox[,] boxes)
        {

             int width = field.GetLength(0);
            int height = field.GetLength(1);
          for (int x = 0; x < width; x++)
              for (int y = 0; y < height; y++)
              {
                  if (field[x, y] == 0)
                      boxes[x, y].Text = "";
                  else
                  boxes[x, y].Text = field[x, y].ToString();
              }
          
        }
        public bool IsValid()
        {
             int[] numbers1to9 = new int[10];
            numbers1to9[1] = 0;
            numbers1to9[2] = 0;
            numbers1to9[3] = 0;
            numbers1to9[4] = 0;
            numbers1to9[5] = 0;
            numbers1to9[6] = 0;
            numbers1to9[7] = 0;
            numbers1to9[8] = 0;
            numbers1to9[9] = 0;
            int i = 0;
            int j = 0;

            //---------Überprüfung aller 3x3 Kasten------------------
            //x
            for (i = 0; i <= 6; i += 3)
            {
                //y
                for (j = 0; j <= 6; j += 3)
                {
                    //y
                    for (int k = j; k <= j + 2; k += 1)
                    {
                        //x
                        for (int l = i; l <= i + 2; l += 1)
                        {
                            //Wenn das aktuelle Feld 1-9 als Inhalt hat -> Erhöhund des entsprechenden Zählers
                            if (field[k, l] == 1 | field[k, l] == 2 | field[k, l] == 3 | field[k, l] == 4 | field[k, l] == 5 | field[k, l] == 6 | field[k, l] == 7 | field[k, l] == 8 | field[k, l] == 9)
                            {
                                numbers1to9[field[k, l]] += 1;
                            }
                        }
                    }
                    //Wenn eine Zahl öfters als ein mal vor kommt -> ungültig
                    if (numbers1to9[1] > 1 || numbers1to9[2] > 1 || numbers1to9[3] > 1 || numbers1to9[4] > 1 || numbers1to9[5] > 1 || numbers1to9[6] > 1 || numbers1to9[7] > 1 || numbers1to9[8] > 1 || numbers1to9[9] > 1)
                    {
                        return false;
                    }
                    numbers1to9[1] = 0;
                    numbers1to9[2] = 0;
                    numbers1to9[3] = 0;
                    numbers1to9[4] = 0;
                    numbers1to9[5] = 0;
                    numbers1to9[6] = 0;
                    numbers1to9[7] = 0;
                    numbers1to9[8] = 0;
                    numbers1to9[9] = 0;
                }
            }
            //-------------------------------------------------------------------

            //---------Überprüfung aller Reihen nacht unten----------------------
            for (i = 0; i <= 8; i++)
            {
                for (j = 0; j <= 8; j++)
                {
                    //Wenn das aktuelle Feld 1-9 als Inhalt hat -> Erhöhund des entsprechenden Zählers
                    if (field[i, j] == 1 | field[i, j] == 2 | field[i, j] == 3 | field[i, j] == 4 | field[i, j] == 5 | field[i, j] == 6 | field[i, j] == 7 | field[i, j] == 8 | field[i, j] == 9)
                    {
                        numbers1to9[field[i, j]] += 1;
                    }
                }
                //Wenn eine Zahl öfters als ein mal vor kommt -> ungültig
                if (numbers1to9[1] > 1 || numbers1to9[2] > 1 || numbers1to9[3] > 1 || numbers1to9[4] > 1 || numbers1to9[5] > 1 || numbers1to9[6] > 1 || numbers1to9[7] > 1 || numbers1to9[8] > 1 || numbers1to9[9] > 1)
                {
                    return false;
                }
                numbers1to9[1] = 0;
                numbers1to9[2] = 0;
                numbers1to9[3] = 0;
                numbers1to9[4] = 0;
                numbers1to9[5] = 0;
                numbers1to9[6] = 0;
                numbers1to9[7] = 0;
                numbers1to9[8] = 0;
                numbers1to9[9] = 0;
            }
            //----------------------------------------------------------------------

            //----------- Überprüfung aller Reihen nach Rechts----------------------
            for (i = 0; i <= 8; i++)
            {
                for (j = 0; j <= 8; j++)
                {
                    //Wenn das aktuelle Feld 1-9 als Inhalt hat -> Erhöhund des entsprechenden Zählers
                    if (field[j, i] == 1 | field[j, i] == 2 | field[j, i] == 3 | field[j, i] == 4 | field[j, i] == 5 | field[j, i] == 6 | field[j, i] == 7 | field[j, i] == 8 | field[j, i] == 9)
                    {
                        numbers1to9[field[j, i]] += 1;
                    }
                }
                //Wenn eine Zahl öfters als ein mal vor kommt -> ungültig
                if (numbers1to9[1] > 1 || numbers1to9[2] > 1 || numbers1to9[3] > 1 || numbers1to9[4] > 1 || numbers1to9[5] > 1 || numbers1to9[6] > 1 || numbers1to9[7] > 1 || numbers1to9[8] > 1 || numbers1to9[9] > 1)
                {
                    return false;
                }
                numbers1to9[1] = 0;
                numbers1to9[2] = 0;
                numbers1to9[3] = 0;
                numbers1to9[4] = 0;
                numbers1to9[5] = 0;
                numbers1to9[6] = 0;
                numbers1to9[7] = 0;
                numbers1to9[8] = 0;
                numbers1to9[9] = 0;
            }
            //----------------------------------------------------------------------

            return true;
        
        }
    }

    class Sudoku
    {
        private SudokuField field;
        
        private int line;

        
        public Sudoku(SudokuField _field)
        {
            field = _field;
            line = 0;
        }

      

        
        public bool solve()
        {

            for (int x = line; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (field.GetValue(x, y) == 0)
                    {
                        for (int val = 1; val <= 9; val++)
                        {
                            //Setze Zahl
                            field.SetField(x, y, val);
                            //Wenn Zahl gültig ist
                            if (field.IsValid())
                            {
                                line = x;
                                //rekursiver Aufruf
                                if (solve())
                                {
                                    //wenn gesetzte Zahl richtig war -> beende Schleife
                                    //wenn nicht -> setze Schleife fort = setze nächste Zahl in Feld
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                //Wenn die Zahl nicht gültig ist
                            }
                            else
                            {
                                //Wenn die Zahl im aktuellen Feld 9 ist -> setze Feld zurück
                                //und return false
                                if (val == 9)
                                {
                                    field.SetField(x, y, 0);
                                    return false;
                                }
                            }
                        }
                    }
       
                }
            }
            return true;
        }

        //private bool fieldValid()
        //{
        //    int[] numbers1to9 = new int[10];
        //    numbers1to9[1] = 0;
        //    numbers1to9[2] = 0;
        //    numbers1to9[3] = 0;
        //    numbers1to9[4] = 0;
        //    numbers1to9[5] = 0;
        //    numbers1to9[6] = 0;
        //    numbers1to9[7] = 0;
        //    numbers1to9[8] = 0;
        //    numbers1to9[9] = 0;
        //    int i = 0;
        //    int j = 0;

        //    //---------Überprüfung aller 3x3 Kasten------------------
        //    //x
        //    for (i = 0; i <= 6; i += 3)
        //    {
        //        //y
        //        for (j = 0; j <= 6; j += 3)
        //        {
        //            //y
        //            for (int k = j; k <= j + 2; k += 1)
        //            {
        //                //x
        //                for (int l = i; l <= i + 2; l += 1)
        //                {
        //                    //Wenn das aktuelle Feld 1-9 als Inhalt hat -> Erhöhund des entsprechenden Zählers
        //                    if (field.GetValue(k, l) == 1 | field.GetValue(k, l) == 2 | field.GetValue(k, l) == 3 | field.GetValue(k, l) == 4 | field.GetValue(k, l) == 5 | field.GetValue(k, l) == 6 | field.GetValue(k, l) == 7 | field.GetValue(k, l) == 8 | field.GetValue(k, l) == 9)
        //                    {
        //                        numbers1to9[field.GetValue(k, l)] += 1;
        //                    }
        //                }
        //            }
        //            //Wenn eine Zahl öfters als ein mal vor kommt -> ungültig
        //            if (numbers1to9[1] > 1 || numbers1to9[2] > 1 || numbers1to9[3] > 1 || numbers1to9[4] > 1 || numbers1to9[5] > 1 || numbers1to9[6] > 1 || numbers1to9[7] > 1 || numbers1to9[8] > 1 || numbers1to9[9] > 1)
        //            {
        //                return false;
        //            }
        //            numbers1to9[1] = 0;
        //            numbers1to9[2] = 0;
        //            numbers1to9[3] = 0;
        //            numbers1to9[4] = 0;
        //            numbers1to9[5] = 0;
        //            numbers1to9[6] = 0;
        //            numbers1to9[7] = 0;
        //            numbers1to9[8] = 0;
        //            numbers1to9[9] = 0;
        //        }
        //    }
        //    //-------------------------------------------------------------------

        //    //---------Überprüfung aller Reihen nacht unten----------------------
        //    for (i = 0; i <= 8; i++)
        //    {
        //        for (j = 0; j <= 8; j++)
        //        {
        //            //Wenn das aktuelle Feld 1-9 als Inhalt hat -> Erhöhund des entsprechenden Zählers
        //            if (field.GetValue(i, j) == 1 | field.GetValue(i, j) == 2 | field.GetValue(i, j) == 3 | field.GetValue(i, j) == 4 | field.GetValue(i, j) == 5 | field.GetValue(i, j) == 6 | field.GetValue(i, j) == 7 | field.GetValue(i, j) == 8 | field.GetValue(i, j) == 9)
        //            {
        //                numbers1to9[field.GetValue(i, j)] += 1;
        //            }
        //        }
        //        //Wenn eine Zahl öfters als ein mal vor kommt -> ungültig
        //        if (numbers1to9[1] > 1 || numbers1to9[2] > 1 || numbers1to9[3] > 1 || numbers1to9[4] > 1 || numbers1to9[5] > 1 || numbers1to9[6] > 1 || numbers1to9[7] > 1 || numbers1to9[8] > 1 || numbers1to9[9] > 1)
        //        {
        //            return false;
        //        }
        //        numbers1to9[1] = 0;
        //        numbers1to9[2] = 0;
        //        numbers1to9[3] = 0;
        //        numbers1to9[4] = 0;
        //        numbers1to9[5] = 0;
        //        numbers1to9[6] = 0;
        //        numbers1to9[7] = 0;
        //        numbers1to9[8] = 0;
        //        numbers1to9[9] = 0;
        //    }
        //    //----------------------------------------------------------------------

        //    //----------- Überprüfung aller Reihen nach Rechts----------------------
        //    for (i = 0; i <= 8; i++)
        //    {
        //        for (j = 0; j <= 8; j++)
        //        {
        //            //Wenn das aktuelle Feld 1-9 als Inhalt hat -> Erhöhund des entsprechenden Zählers
        //            if (field.GetValue(j, i) == 1 | field.GetValue(j, i) == 2 | field.GetValue(j, i) == 3 | field.GetValue(j, i) == 4 | field.GetValue(j, i) == 5 | field.GetValue(j, i) == 6 | field.GetValue(j, i) == 7 | field.GetValue(j, i) == 8 | field.GetValue(j, i) == 9)
        //            {
        //                numbers1to9[field.GetValue(j, i)] += 1;
        //            }
        //        }
        //        //Wenn eine Zahl öfters als ein mal vor kommt -> ungültig
        //        if (numbers1to9[1] > 1 || numbers1to9[2] > 1 || numbers1to9[3] > 1 || numbers1to9[4] > 1 || numbers1to9[5] > 1 || numbers1to9[6] > 1 || numbers1to9[7] > 1 || numbers1to9[8] > 1 || numbers1to9[9] > 1)
        //        {
        //            return false;
        //        }
        //        numbers1to9[1] = 0;
        //        numbers1to9[2] = 0;
        //        numbers1to9[3] = 0;
        //        numbers1to9[4] = 0;
        //        numbers1to9[5] = 0;
        //        numbers1to9[6] = 0;
        //        numbers1to9[7] = 0;
        //        numbers1to9[8] = 0;
        //        numbers1to9[9] = 0;
        //    }
        //    //----------------------------------------------------------------------

        //    return true;
        //}

        public SudokuField GetField()
        {
            return field;
        }

        public SudokuField GetField(ref System.Windows.Forms.TextBox[,] boxes)
        {
            field.Field2textboxes(ref boxes);
            return field;
        }


    }
}