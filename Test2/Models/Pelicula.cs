using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;

namespace Test2.Models
{
    public class Pelicula
    {
     

        public List<ProductionCountry> ProductionCountries { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public ResultContainer<ReleaseDatesContainer> ReleaseDates { get; set; }

        public ExternalIdsMovie ExternalIds { get; set; }

        public Releases Releases { get; set; }

        public long Revenue { get; set; }

        public SearchContainer<ReviewBase> Reviews { get; set; }

        public int? Runtime { get; set; }

        public SearchContainer<SearchMovie> Similar { get; set; }

        public SearchContainer<SearchMovie> Recommendations { get; set; }
        public List<SpokenLanguage> SpokenLanguages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public TranslationsContainer Translations { get; set; }
        public bool Video { get; set; }
        public ResultContainer<Video> Videos { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public double VoteAverage { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
        public AccountState AccountStates { get; set; }
        public bool Adult { get; set; }
        public AlternativeTitles AlternativeTitles { get; set; }
        public string BackdropPath { get; set; }
        public SearchCollection BelongsToCollection { get; set; }
        public long Budget { get; set; }
        public ChangesContainer Changes { get; set; }
        public Credits Credits { get; set; }

        public List<Cast> listCast { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public Images Images { get; set; }
        public string ImdbId { get; set; }
        public KeywordsContainer Keywords { get; set; }
        public SearchContainer<ListResult> Lists { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public double Popularity { get; set; }
        public int VoteCount { get; set; }

        public ResultContainer<Video> listVideo { get; set; }

        public string trailerPath { get; set; }

        public DateTime horario { get; set; }

        public sala sala { get; set; }

        public List<funcion> listFunciones{get; set;}


    }
}