﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    #region properties
    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Null is invalid value of 'FirstName'.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Null is invalid value of 'LastName'.");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        set
        {
            this.exams = value;
        }
    }
    #endregion

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new InvalidOperationException("Can not perform CheckExam on object of type 'Student' with value of 'Exams' as null. ");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Can not perform CheckExam on object of type 'Student' with value of 'Exams' as empty collection.");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new InvalidOperationException("Can not perform CalcAverageExamResultInPercents on object of type 'Student' with value of 'Exams' as null. ");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Can not perform CalcAverageExamResultInPercents on object of type 'Student' with value of 'Exams' as empty collection.");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
