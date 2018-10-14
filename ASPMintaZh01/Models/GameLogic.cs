using ASPMintaZh01.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMintaZh01.Models
{
    public class GameLogic
    {
        SuperHeroContext dbcontext;
        public GameLogic(SuperHeroContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void AddHero(SuperHeroViewModel vm)
        {
            byte[] picture = new byte[vm.ImageToUpload.Length];
            using (var stream = vm.ImageToUpload.OpenReadStream())
            {
                stream.Read(picture, 0, (int)vm.ImageToUpload.Length);
            }
                SuperHeroModel model = new SuperHeroModel()
                {
                    Name = vm.Name,
                    ContentType = vm.ImageToUpload.ContentType,
                    Health = 100,
                    Power = vm.Power,
                    Side = vm.Side,
                    Speed = vm.Speed,
                    Magic = vm.Magic,
                    Image = picture
                };
            dbcontext.SuperHeroes.Add(model);
            dbcontext.SaveChanges();
        }

        public void DeleteHero(int id)
        {
            var q = from x in dbcontext.SuperHeroes
                    where x.Id == id
                    select x;
            dbcontext.SuperHeroes.Remove(q.FirstOrDefault());
            dbcontext.SaveChanges();
        }

        public SuperHeroModel GetHeroById(int id)
        {
            var q = from x in dbcontext.SuperHeroes
                    where x.Id == id
                    select x;
            return q.FirstOrDefault();
        }

        private void UpdateHero(SuperHeroModel model)
        {
            //var q = from x in dbcontext.SuperHeroes
            //        where x.Id == model.Id
            //        select x;
            //dbcontext.Remove(q.FirstOrDefault());
            //dbcontext.Add(model);

            dbcontext.Update(model);

            dbcontext.SaveChanges();
            
        }

        public IEnumerable<SuperHeroModel> GetAllHero(string side="all")
        {
            if (side == "all")
            {
                return dbcontext.SuperHeroes;
            }
            else
            {
                var q = from x in dbcontext.SuperHeroes
                        where x.Side == side
                        select x;
                return q;
            }
        }

        public void ResetHealth()
        {
            foreach (var item in dbcontext.SuperHeroes)
            {
                item.Health = 100;
            }
            dbcontext.SaveChanges();
        }

        public FightViewModel Fight(int id)
        {
            Random r = new Random();

            //get player
            var playerModel = this.GetHeroById(id);

            //detect player's side
            var q = from x in dbcontext.SuperHeroes
                    where x.Id == id
                    select x.Side;
            string playerSide = q.FirstOrDefault();

            //get computer
            SuperHeroModel computerModel = null;
            if (playerSide == "light")
            {
                var all = this.GetAllHero("dark");
                var allList = all.ToList();
                computerModel = allList[r.Next(0, allList.Count)];
            }
            else
            {
                var all = this.GetAllHero("light");
                var allList = all.ToList();
                computerModel = allList[r.Next(0, allList.Count)];
            }

            string winner = "";

            //who is the stronger?
            double playerPoint = (double)(playerModel.Speed + playerModel.Power + playerModel.Magic + playerModel.Health) / 4;

            double computerPoint = (double)(computerModel.Speed + computerModel.Power + computerModel.Magic + computerModel.Health) / 4;

            if (playerPoint > computerPoint)
            {
                computerModel.Health -= (int)((computerModel.Health) * ((double)r.Next(0, 70) / (double)100));
                playerModel.Health -= (int)((playerModel.Health) * ((double)r.Next(0, 30) / (double)100));
                winner = playerModel.Name;
            }
            else
            {
                playerModel.Health -= (int)((playerModel.Health) * ((double)r.Next(0, 70) / (double)100));
                computerModel.Health -= (int)((computerModel.Health) * ((double)r.Next(0, 30) / (double)100));
                winner = computerModel.Name;
            }

            FightViewModel fvm = new FightViewModel()
            {
                Player = playerModel,
                Computer = computerModel,
                Winner = winner
            };

            this.UpdateHero(playerModel);
            this.UpdateHero(computerModel);

            return fvm;

        }
    }
}
