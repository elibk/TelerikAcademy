﻿using System;
using System.IO;
using System.Linq;
using System.Text;

///////////////////////////////////////////////////////////////////////
namespace P1CleanCode
{
    class CleanCode
    {
        static void Main(string[] args)
        {
            //StreamReader read = new StreamReader(@"...\...\TextFile.txt", Encoding.GetEncoding("windows-1251"));
            int numOfLines = int.Parse(Console.ReadLine());
            StringBuilder strbulder = new StringBuilder();


            bool inOnelinecomment = false;

            bool inMultilineComment = false;

            bool inOneLineString = false;
            bool escaping = false;

            bool inChar = false;

            bool inMultiLineString = false;

            bool inCode = true;



            for (int i = 0; i < numOfLines; i++)
            {
                string line = Console.ReadLine();
                for (int ind = 0; ind < line.Length; ind++)
                {
                    char symbol = line[ind];

                    //if (symbol == -1)
                    //{
                    //    break;
                    //}

                    //if (inOnelinecomment)
                    //{

                    //}

                    if (inMultilineComment == true)
                    {

                        if (symbol == '*' && ind < line.Length - 1)
                        {
                            if (line[ind + 1] == '/')
                            {
                                inMultilineComment = false;
                                inCode = true;
                            }

                            if (inMultilineComment == false)
                            {
                                if (ind < line.Length - 2)
                                {
                                    symbol = line[ind + 2];
                                    ind = ind + 2;
                                }
                                else
                                {
                                    break;
                                }
                            }



                        }
                    }

                    else if (inChar == true)
                    {
                        if (escaping == false)
                        {
                            if (symbol == '\\')
                            {
                                escaping = true;
                                strbulder.Append(symbol);
                            }
                            else if (symbol == '\'')
                            {
                                strbulder.Append(symbol);
                                inChar = false;
                                inCode = true;
                                continue;
                            }
                            else
                            {
                                strbulder.Append(symbol);
                            }
                        }
                        else
                        {

                            strbulder.Append(symbol);
                            escaping = false;

                        }




                    }
                    else if (inOneLineString)
                    {
                        if (escaping == false)
                        {
                            if (symbol == '\\')
                            {
                                escaping = true;
                                strbulder.Append(symbol);
                            }
                            else if (symbol == '"')
                            {
                                strbulder.Append(symbol);
                                inOneLineString = false;
                                inCode = true;
                                continue;
                            }
                            else
                            {
                                strbulder.Append(symbol);
                            }
                        }
                        else
                        {

                            strbulder.Append(symbol);
                            escaping = false;

                        }
                        //string str = @"""";

                    }

                    else if (inMultiLineString)
                    {
                        if (symbol == '"')
                        {
                            escaping = true;
                            strbulder.Append(symbol);
                        }
                        else
                        {
                            if (escaping)
                            {
                                if (symbol != '"')
                                {
                                    escaping = false;
                                    inMultiLineString = false;
                                    inCode = true;
                                }
                                else
                                {
                                    strbulder.Append(symbol);
                                    escaping = false;
                                }
                            }
                            else
                            {
                                strbulder.Append(symbol);
                            }
                        }
                    }

                    if (inCode)
                    {
                        if (symbol == '/')
                        {
                            if (line[ind + 1] == '*')
                            {
                                inMultilineComment = true;
                                inCode = false;
                                ind++;
                            }
                            else if (line[ind + 1] == '/')
                            {
                                inOnelinecomment = true;
                                inCode = false;
                                ind++;
                            }
                        }
                        else if (symbol == '"')
                        {
                            inCode = false;
                            inOneLineString = true;
                            strbulder.Append(symbol);
                        }
                        else if (symbol == '\'')
                        {
                            inChar = true;
                            inCode = false;
                            strbulder.Append(symbol);
                        }
                        else if (symbol == '@')
                        {

                            if (line[ind + 1] == '"')
                            {
                                inCode = false;
                                inMultiLineString = true;
                                strbulder.Append(symbol);
                                strbulder.Append(line[ind + 1]);
                                ind++;
                            }

                        }
                        else
                        {
                            strbulder.Append(symbol);
                        }
                    }
                }

                if (inMultiLineString)
                {
                    Console.WriteLine(strbulder.ToString());

                    strbulder.Clear();
                }
                else
                {
                    if (inOnelinecomment)
                    {
                        inOnelinecomment = false;
                        inCode = true;
                    }

                    if (inCode)
                    {

                        if (strbulder.ToString().Trim().Length == 0)
                        {

                        }
                        else
                        {
                            Console.WriteLine(strbulder.ToString());
                        }

                        strbulder.Clear();
                    }
                }


            }
        }
    }
}