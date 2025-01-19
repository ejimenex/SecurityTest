# SecurityTest

## Descripción

Este proyecto es un api para crear usuarios.

## Como se usa?

- Luego de clonado, debe tener instalado .net 8 en su computadora.
- Debe cambiar el connection string y cambiarlo para que apunte a su servidor de base de datos.
- Debe correr un migration para que se cree la tabla en su servidor de base de datos
- Ejeutar este comando update-database SecondMigration

## En caso de tener inconvenientes con el migration, ejecutar el siguiente query en su servidor

```sql CREATE DATABASE [SecurityTest]
use [SecurityTest]
GO
ALTER DATABASE [SecurityTest] SET COMPATIBILITY_LEVEL = 160
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](500) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Role] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
ALTER DATABASE [SecurityTest] SET  READ_WRITE 
GO

