using System;
namespace csharp_day3_;

class Program
{
    static void Main(string[] args)
    {
            string[,] map = new String[4, 4];

             Console.WriteLine("Nhập giá trị cho game:");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("Nhập giá trị cho phần tử [{0}, {1}]: ", i, j);
                    string value = Console.ReadLine();

                    map[i, j] = value;
                }
            }

            int MAP_HEIGHT = map.GetLength(0);
            int MAP_WIDTH = map.GetLength(1);

            string[,] mapReport = new string[MAP_HEIGHT, MAP_WIDTH];
            for (int yOrdinate = 0; yOrdinate < MAP_HEIGHT; yOrdinate++)
            {
                for (int xOrdinate = 0; xOrdinate < MAP_WIDTH ; xOrdinate++)
                {
                    string curentCell = map[yOrdinate, xOrdinate];
                    if (curentCell.Equals("*"))
                    {
                        mapReport[yOrdinate, xOrdinate] = "*";
                    }
                    else
                    {
                        int[,] NEIGHBOURS_ORDINATE = {
                        {yOrdinate - 1, xOrdinate - 1}, {yOrdinate - 1, xOrdinate}, {yOrdinate - 1, xOrdinate + 1},
                        {yOrdinate, xOrdinate - 1}, {yOrdinate, xOrdinate + 1},
                        {yOrdinate + 1, xOrdinate - 1}, {yOrdinate + 1, xOrdinate}, {yOrdinate + 1, xOrdinate + 1},};

                        int minesAround = 0;
                        int length = NEIGHBOURS_ORDINATE.GetLength(0);
                        for (int i = 0; i < length; i++)
                        {
                            int xOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 1];
                            int yOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 0];

                            bool isOutOfMapNeighbour = xOrdinateOfNeighbour < 0
                                    || xOrdinateOfNeighbour == MAP_WIDTH
                                    || yOrdinateOfNeighbour < 0
                                    || yOrdinateOfNeighbour == MAP_HEIGHT;
                            if (isOutOfMapNeighbour)
                            {
                                continue;
                            }

                            bool isMineOwnerNeighbour = map[yOrdinateOfNeighbour, xOrdinateOfNeighbour].Equals("*");
                            if (isMineOwnerNeighbour)
                            {
                                minesAround++;
                            }
                        }

                        mapReport[yOrdinate, xOrdinate] = minesAround.ToString();
                    }
                }
            }

            for (int yOrdinate = 0; yOrdinate < MAP_HEIGHT; yOrdinate++)
            {
                Console.WriteLine("\n");
                for (int xOrdinate = 0; xOrdinate < MAP_WIDTH; xOrdinate++)
                {
                    String currentCellReport = mapReport[yOrdinate, xOrdinate];
                    Console.Write(currentCellReport);
                }
            }
            Console.ReadLine();
    }
}
