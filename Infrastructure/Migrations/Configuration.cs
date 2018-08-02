namespace Infrastructure.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.DemographicsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        

        protected override void Seed(Infrastructure.DemographicsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.People.AddOrUpdate(x => x.PersonId,
                new Person() { PersonId = 1, FirstName = "Bobbe", LastName = "Eckh", Email = "beckh0@ucsd.edu",
                    DateOfBirth = new DateTime(1944, 11, 20, 13, 45, 0), HomePhone = "(212)-546-2853", MobilePhone = "(303)-266-9293",
                    Address =  new Address()
                    {
                        AddressId = 1,
                        Address1 = "1026 Blaine Pass",
                        Address2 = "199 Kensington Place",
                        City = "New York City",
                        State = "NY",
                        Zipcode = "10131"
                    }
                },

                new Person() { PersonId = 2 ,FirstName = "Denny" ,LastName = "Konzel" ,Email = "dkonzelb@goo.gl" ,
                    DateOfBirth = new DateTime(1978, 03, 21, 10, 15, 0), HomePhone = "(513)-564-5948" ,MobilePhone = "(801)-399-3898",
                    Address = new Address
                    {
                        AddressId = 2,
                        Address1 = "99 Burrows Terrace",
                        Address2 = "47 Lyons Drive",
                        City = "Cincinnati",
                        State = "OH",
                        Zipcode = "45203"
                    }
                }, 

                new Person() { PersonId = 3 ,FirstName = "Johannes" ,LastName = "Jachimczak" ,Email = "jjachimczakc@addtoany.com" ,
                    DateOfBirth = new DateTime(1943, 06, 03, 02, 05, 0) ,HomePhone = "(432)-627-5160" ,MobilePhone = "(818)-762-6215",
                    Address = new Address
                    {
                        AddressId = 3,
                        Address1 = "02801 Maywood Way",
                        Address2 = "23588 Gulseth Street",
                        City = "Midland",
                        State = "TX",
                        Zipcode = "79710"
                    }
                }, 

                new Person() { PersonId = 4 ,FirstName = "Fanya" ,LastName = "Cannan" ,Email = "fcannand@newyorker.com",
                    DateOfBirth = new DateTime(1977, 11, 07, 12, 31, 0), HomePhone = "(412)-602-4844" ,MobilePhone = "(304)-616-7035",
                    Address = new Address
                    {
                        AddressId = 4,
                        Address1 = "4137 Petterle Hill" ,
                        Address2 = "5 Huxley Way" ,
                        City = "Mc Keesport" ,
                        State = "PA" ,
                        Zipcode = "15134" ,
                    }
                },
                
                new Person() { PersonId = 5 ,FirstName = "Damara" ,LastName = "Dudding" ,Email = "dduddinge@ibm.com" ,
                    DateOfBirth = new DateTime(1963, 04, 12, 07, 28, 0), HomePhone = "(561)-510-0871" ,MobilePhone = "(603)-922-2517" ,
                    Address = new Address
                    {
                        AddressId = 5,
                        Address1 = "10183 Northland Hill" ,
                        Address2 = "1020 Miller Road" ,
                        City = "West Palm Beach" ,
                        State = "FL" ,Zipcode = "33416"
                    }
                }          
                
                );



        }
    }
}
