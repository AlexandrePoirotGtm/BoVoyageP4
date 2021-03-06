﻿using BoVoyageP4.Enumeration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageP4.Models
{
    public class Participant : Personne
    {
        [NotMapped]
        public double Reduction
        {
            get
            {
                if (Age < 12)
                    return 0.6d;
                else
                    return 1.0d;
            }
        }

        public int? IDDossierReservation { get; set; }

        [ForeignKey("IDDossierReservation")]
        public DossierReservation DossierReservation { get; set; }

        public Participant()
        {
        }

        public Participant(Civilite civ, string nom, string prenom, string adresse, string tel, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Civilite = civ;
            Telephone = tel;
            DateNaissance = dateNaissance;
        }

        public override string ToString()
        {
            return $"({ID}) {Nom.ToUpper()},{Prenom.ToLower()} - Ad. {Adresse}";
        }
    }
}