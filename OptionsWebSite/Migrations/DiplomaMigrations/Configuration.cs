namespace OptionsWebSite.Migrations.DiplomaMigrations
{
    using DiplomaDataModel.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiplomaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DiplomaMigrations";
        }

        protected override void Seed(DiplomaContext context)
        {
            context.YearTerms.AddOrUpdate(y => y.YearTermId, new YearTerm { YearTermId = 1, Year = 2015, Term = 10, IsDefault = false });
            context.YearTerms.AddOrUpdate(y => y.YearTermId, new YearTerm { YearTermId = 2, Year = 2015, Term = 20, IsDefault = false });
            context.YearTerms.AddOrUpdate(y => y.YearTermId, new YearTerm { YearTermId = 3, Year = 2015, Term = 30, IsDefault = false });
            context.YearTerms.AddOrUpdate(y => y.YearTermId, new YearTerm { YearTermId = 4, Year = 2016, Term = 10, IsDefault = true });

            context.SaveChanges();

            context.Options.AddOrUpdate(o => o.OptionId, new Option { OptionId = 1, Title = "Web and Mobile",       IsActive = true });
            context.Options.AddOrUpdate(o => o.OptionId, new Option { OptionId = 2, Title = "Client Server",        IsActive = true });
            context.Options.AddOrUpdate(o => o.OptionId, new Option { OptionId = 3, Title = "Digital Processing",   IsActive = true });
            context.Options.AddOrUpdate(o => o.OptionId, new Option { OptionId = 4, Title = "Informations Systems", IsActive = true });
            context.Options.AddOrUpdate(o => o.OptionId, new Option { OptionId = 5, Title = "Database",             IsActive = false });
            context.Options.AddOrUpdate(o => o.OptionId, new Option { OptionId = 6, Title = "Data Communications",  IsActive = true });
            context.Options.AddOrUpdate(o => o.OptionId, new Option { OptionId = 7, Title = "Tech Pro",             IsActive = false });

            context.SaveChanges();

            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  1,
                YearTermId = 4,
                StudentId = "A00111111",
                StudentFirstName = "John",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });

            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  2,
                YearTermId = 4,
                StudentId = "A00222222",
                StudentFirstName = "James",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  3,
                YearTermId = 4,
                StudentId = "A00333333",
                StudentFirstName = "Jeff",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 3,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 6,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  4,
                YearTermId = 4,
                StudentId = "A00444444",
                StudentFirstName = "Jane",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 6,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  5,
                YearTermId = 4,
                StudentId = "A00555555",
                StudentFirstName = "Jim",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 6,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  6,
                YearTermId = 4,
                StudentId = "A00666666",
                StudentFirstName = "Janice",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 6,
                ThirdChoiceOptionId = 4,
                FourthChoiceOptionId = 2,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  7,
                YearTermId = 4,
                StudentId = "A00777777",
                StudentFirstName = "Jenny",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  8,
                YearTermId = 4,
                StudentId = "A00888888",
                StudentFirstName = "Jox",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId =  9,
                YearTermId = 4,
                StudentId = "A00999999",
                StudentFirstName = "Jan",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 3,
                ThirdChoiceOptionId = 6,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 10,
                YearTermId = 4,
                StudentId = "A00101010",
                StudentFirstName = "Johnny",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 4,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 3,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 11,
                YearTermId = 3,
                StudentId = "A00111111",
                StudentFirstName = "Jeremy",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 12,
                YearTermId = 3,
                StudentId = "A00222222",
                StudentFirstName = "Justin",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 6,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 13,
                YearTermId = 3,
                StudentId = "A00333333",
                StudentFirstName = "Jupiter",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 6,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 14,
                YearTermId = 3,
                StudentId = "A00444444",
                StudentFirstName = "Jerimiah",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 3,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 15,
                YearTermId = 3,
                StudentId = "A00555555",
                StudentFirstName = "Jered",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 7,
                ThirdChoiceOptionId = 4,
                FourthChoiceOptionId = 2,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 16,
                YearTermId = 3,
                StudentId = "A00666666",
                StudentFirstName = "Jacky",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 7,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 17,
                YearTermId = 3,
                StudentId = "A00777777",
                StudentFirstName = "Joanne",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 4,
                ThirdChoiceOptionId = 7,
                FourthChoiceOptionId = 2,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 18,
                YearTermId = 3,
                StudentId = "A00888888",
                StudentFirstName = "Jonnah",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 3,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 7,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 19,
                YearTermId = 3,
                StudentId = "A00999999",
                StudentFirstName = "Jedidiah",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 4,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 7,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice { ChoiceId = 20,
                YearTermId = 3,
                StudentId = "A00202020",
                StudentFirstName = "Jay",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 5,
                SecondChoiceOptionId = 4,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 2,
                SelectionDate = DateTime.Now
            });

            context.SaveChanges();
        }
    }
}
