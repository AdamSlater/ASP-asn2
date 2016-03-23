enable-migrations -ContextProject DiplomaDataModel  -ContextTypeName DiplomaContext -MigrationsDirectory Migrations\DiplomaMigrations

add-migration -ConfigurationTypeName OptionsWebSite.Migrations.DiplomaMigrations.Configuration "InitSeed"

update-database -ConfigurationTypeName OptionsWebSite.Migrations.DiplomaMigrations.Configuration




enable-migrations -ContextProject DiplomaDataModel  -ContextTypeName ApplicationDbContext -MigrationsDirectory Migrations\ApplicationsMigrations

add-migration -ConfigurationTypeName OptionsWebSite.Migrations.ApplicationsMigrations.Configuration "InitUsers"

update-database -ConfigurationTypeName OptionsWebSite.Migrations.ApplicationsMigrations.Configuration
