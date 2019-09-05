using SittingPlan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Initializers
{
    public class SittingPlanInitializer : DropCreateDatabaseAlways<SittingPlanContext>
    {
        protected override void Seed(SittingPlanContext context)
        {
            var initialPeople = new List<Person>();

            initialPeople.Add(new Person
            {
                Id = 1,
                Name = "ertug ",
                Surname = "dilek",
                Mail = "ertgdl@gmail.com",

            });
            initialPeople.Add(new Person
            {
                Id = 2,
                Name = "aral ",
                Surname = "karaoglan",
                Mail = "ertgdl@gmail.com",

            });
            initialPeople.Add(new Person
            {
                Id = 3,
                Name = "berke ",
                Surname = "karaduman",
                Mail = "ertgdl@gmail.com",

            });
            initialPeople.Add(new Person
            {
                Id = 4,
                Name = "berke ",
                Surname = "idris",
                Mail = "ertgdl@gmail.com",

            });
            initialPeople.Add(new Person
            {
                Id = 5,
                Name = "atakan ",
                Surname = "uzun",
                Mail = "ertgdl@gmail.com",

            });

            context.People.AddRange(initialPeople);


            var initialChair = new List<Chair>();

            initialChair.Add(new Chair
            {
                Id = 1,
                Person = context.People.Find(2),

            });
            initialChair.Add(new Chair
            {
                Id = 2,
                Person = context.People.Find(4),

            });
            initialChair.Add(new Chair
            {
                Id = 3,
                Person = context.People.Find(1),

            });
            initialChair.Add(new Chair
            {
                Id = 4,
                Person = context.People.Find(5),

            });
            initialChair.Add(new Chair
            {
                Id = 5,
                Person = context.People.Find(3),

            });

            context.Chairs.AddRange(initialChair);

            var initialDesks = new List<Desk>();
            var list1 = new List<Chair>
            {
                context.Chairs.Find(5),
                context.Chairs.Find(4)

            };
            var list2 = new List<Chair> {
                context.Chairs.Find(3),
                context.Chairs.Find(2),

            };

            var list3 = new List<Chair> {

                context.Chairs.Find(1)
            };

            initialDesks.Add(new Desk
            {
                Id = 1,
                Name = "Desk 1",
                Chairs = list1
            });

            initialDesks.Add(new Desk
            {
                Id = 2,
                Name = "Desk 2",
                Chairs = list2

            });

            initialDesks.Add(new Desk
            {
                Id = 3,
                Name = "Desk 3",
                Chairs = list3

            });

            context.Desk.AddRange(initialDesks);

            var initialFloors = new List<Floor>();
            var listf = new List<Desk> {
                context.Desk.Find(3),
                context.Desk.Find(2)

            };

            var listff = new List<Desk> {

                context.Desk.Find(1)
            };

            initialFloors.Add(new Floor
            {
                Id = 1,
                Name = "Lobby",
                Desks = listf

            });


            initialFloors.Add(new Floor
            {
                Id = 2,
                Name = "IT Floor",
                Desks = listff


            });



            context.Floors.AddRange(initialFloors);


            base.Seed(context);
        }
    }
}
