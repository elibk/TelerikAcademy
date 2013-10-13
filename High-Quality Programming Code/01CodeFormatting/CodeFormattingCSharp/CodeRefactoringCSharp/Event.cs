﻿using System;
using System.Linq;
using System.Text;

internal class Event : IComparable 
{
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.Date = date;
        this.Title = title;
        this.Location = location;
    }

    public DateTime Date
    {
        get
        {
            return this.date;
        }

        set
        {
            this.date = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }

        set
        {
            this.title = value;
        }
    }

    public string Location
    {
        get
        {
            return this.location;
        }

        set
        {
            this.location = value;
        }
    }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int byDate = this.date.CompareTo(other.date);
        int byTitle = this.title.CompareTo(other.title);

        int byLocation = this.location.CompareTo(other.location);
        if (byDate == 0)
        {
            if (byTitle == 0)
            {
                return byLocation;
            }
            else
            {
                return byTitle;
            }
        }
        else
        {
            return byDate;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        result.Append(" | " + this.title);

        if (this.location != null && this.location != string.Empty)
        {
            result.Append(" | " + this.location);
        }

        return result.ToString();
    }
}
