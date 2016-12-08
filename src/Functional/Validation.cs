using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Functional
{
    public class Validation
    {
        public bool IsValidMovie1(Movie movie)
        {
            if(string.IsNullOrEmpty(movie.Title))
            {
                return false;
            }   

            if(movie.Length > 300 || movie.Length < 60)
            {
                return false;
            }

            if(movie.ReleaseDate.Year < 1920)
            {
                return false;
            }
            return true;
        }

        public bool IsValidMovie2(Movie movie)
        {
            Predicate<Movie>[] rules =
                {
                    m => !String.IsNullOrEmpty(movie.Title),
                    m => m.Length > 90 && m.Length < 120,
                    m => m.ReleaseDate.Year > 1920
                };

            foreach(var rule in rules)
            {
                if(!rule(movie))
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<ValidationResult> IsValidMovie3(Movie movie)
        {
            Rule<Movie>[] rules =
                {
                    new Rule<Movie>(m => !String.IsNullOrEmpty(movie.Title), 
                                         "Title cannot be empty"),
                    new Rule<Movie>(m => m.Length > 90 && m.Length < 120,
                                         "Length is invalid"),
                    new Rule<Movie>(m => m.ReleaseDate.Year > 1920,
                                         "Date is out of range")
                };

            var result = rules.Where(r => r.Predicate(movie) == false)
                              .Select(r => new ValidationResult(r.ErrorMessage));

            return result;
        }
    }


    public class Rule<T>
    {
        public Rule(Predicate<T> predicate, string errorMessage)
        {
            Predicate = predicate;
            ErrorMessage = errorMessage;
        }

        public Predicate<T> Predicate { get; set; }
        public string ErrorMessage { get; set; }
    }

}