using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MovieStore.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1906, 2050,
        ErrorMessage = "Value for 'Year' must be between 1906 and 2050.")]
        public int Year { get; set; }

        private IQueryable<MemberInMovieModel> leadingActors;
        private IQueryable<MemberInMovieModel> leadingActresses;

        private IQueryable<MemberInMovieModel> directors;
        public MovieModel()
        {
            this.leadingActors = new HashSet<MemberInMovieModel>().AsQueryable();
            this.leadingActresses = new HashSet<MemberInMovieModel>().AsQueryable();
            this.directors = new HashSet<MemberInMovieModel>().AsQueryable();
        }

        public IQueryable<MemberInMovieModel> LeadingActors
        {
            get
            {
                return this.leadingActors;
            }
            set
            {
                this.leadingActors = value;
            }
        }

        public IQueryable<MemberInMovieModel> LeadingActresses
        {
            get
            {
                return this.leadingActresses;
            }
            set
            {
                this.leadingActresses = value;
            }
        }

        public IQueryable<MemberInMovieModel> Directors
        {
            get
            {
                return this.directors;
            }
            set
            {
                this.directors = value;
            }
        }

        public static Expression<Func<Movie, MovieModel>> FromProductToProductModel
        {
            get
            {
                return x => new MovieModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Year = x.Year,
                    LeadingActors = x.ArtistsRoles.Where(a => a.RoleType == RoleType.LeadingMale).Select(m => m.MemberInMovie).AsQueryable().Select(MemberInMovieModel.FromMemeberInMovie),
                    LeadingActresses = x.ArtistsRoles.Where(a => a.RoleType == RoleType.LeadingFemale).Select(m => m.MemberInMovie).AsQueryable().Select(MemberInMovieModel.FromMemeberInMovie),
                    Directors = x.ArtistsRoles.Where(a => a.RoleType == RoleType.Director).Select(m => m.MemberInMovie).AsQueryable().Select(MemberInMovieModel.FromMemeberInMovie),
                };
            }
        }
    }
}