using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using BLL.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class LocataireService
    {
        private readonly LocaRepository _locaRepository;

        public LocataireService(LocaRepository repo)
        {
            _locaRepository = repo;
        }



        public IEnumerable<Locataire> GetAllDto()
        {
            var locataires = _locaRepository.GetAll();

            var locatairesDtos = new List<Locataire>();
            foreach(var locataire in locataires)
            {
                locatairesDtos.Add(LocataireMapper.toModele(locataire));
            }
            return locatairesDtos;
        }


        public Locataire Insert(Locataire locataire)
        {
            var LocataireEntity = LocataireMapper.toEntity(locataire);

            _locaRepository.Create(locataire); //finir methode dans la dal repo car la je l ai pas
        }
    }
}
