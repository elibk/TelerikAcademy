﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPopGame.Common
{
    public class Player : IPlayer
    {
        private string name;
        private int score;

        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
           protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Value for 'Name' can not be 'null', empty string or consists only white spaces.");
                }

                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
           protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value for 'Score' can not be negative number.");
                }

                this.score = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.Name);
            result.Append(" --> ");
            result.Append(this.Score);
            result.Append(" move");

            if (this.Score != 1)
            {
                result.Append('s');
            }

            return result.ToString();
        }
    }
}
