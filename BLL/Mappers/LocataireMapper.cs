using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = DAL.Entities; //faut ajouter reference projet

namespace BLL.Mappers
{
    public static class LocataireMapper
    {


        public static Models.Locataire toModele(this Entities.Locataire locataire)
        {
            return new Models.Locataire
            {
                id = locataire.id,
                nom = locataire.nom,
                prenom = locataire.prenom,
                mail = locataire.mail,
                telephone = locataire.telephone,
                description = locataire.description
            };
        }

        public static Entities.Locataire toEntity(this Models.Locataire locataire)
        {
            return new Entities.Locataire
            {
                id = locataire.id,
                nom = locataire.nom,
                prenom = locataire.prenom,
                mail = locataire.mail,
                telephone = locataire.telephone,
                description = locataire.description
            };
        }

    }
}
