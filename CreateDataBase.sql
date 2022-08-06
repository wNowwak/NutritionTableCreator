/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     30.07.2022 10:20:59                          */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('Jednostki')
            and   type = 'U')
   drop table Jednostki
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Produkty')
            and   type = 'U')
   drop table Produkty
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Receptury')
            and   name  = 'Relationship_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index Receptury.Relationship_3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Receptury')
            and   name  = 'Relationship_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Receptury.Relationship_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Receptury')
            and   type = 'U')
   drop table Receptury
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Skladniki')
            and   type = 'U')
   drop table Skladniki
go

/*==============================================================*/
/* Table: Jednostki                                             */
/*==============================================================*/
create table Jednostki (
   Jednostka_Id         int        IDENTITY(1,1)          not null,
   Jednostka_Nazwa      varchar(1024)        not null,
   Jednostka_Mnoznik	int					 not null,
   constraint PK_JEDNOSTKI primary key nonclustered (Jednostka_Id)
)
go

/*==============================================================*/
/* Table: Produkty                                              */
/*==============================================================*/
create table Produkty (
   Produkt_Id           int         IDENTITY(1,1)         not null,
   Produkt_Nazwa        varchar(1024)        not null,
   constraint PK_PRODUKTY primary key nonclustered (Produkt_Id)
)
go

/*==============================================================*/
/* Table: Receptury                                             */
/*==============================================================*/
create table Receptury (
   Receptura_Id         int        IDENTITY(1,1)          not null,
   Produkt_Id           int                  not null,
   Skladnik_Id          int                  not null,
   Ilosc                decimal(10,4)                  not null,
   Jednostka_Id         int                  not null,
   Ilosc_Gotowa         decimal(10,4)                  not null,
   JednostkaGotowa_Id         int                  not null,
   constraint PK_RECEPTURY primary key nonclustered (Receptura_Id)
)
go

/*==============================================================*/
/* Index: Relationship_2_FK                                     */
/*==============================================================*/
create index Relationship_2_FK on Receptury (
Jednostka_Id ASC
)
go

/*==============================================================*/
/* Index: Relationship_3_FK                                     */
/*==============================================================*/
create index Relationship_3_FK on Receptury (
Skladnik_Id ASC
)
go

/*==============================================================*/
/* Table: Skladniki                                             */
/*==============================================================*/
create table Skladniki (
   Skladnik_Id          int        IDENTITY(1,1)          not null,
   Skaldnik_Nazwa       varchar(1024)        not null,
   constraint PK_SKLADNIKI primary key nonclustered (Skladnik_Id)
)
go



INSERT INTO Jednostki (Jednostka_Nazwa, Jednostka_Mnoznik) VALUES ('kilogram',3)
INSERT INTO Jednostki (Jednostka_Nazwa, Jednostka_Mnoznik) VALUES ('miligram', -3)
INSERT INTO Jednostki (Jednostka_Nazwa, Jednostka_Mnoznik) VALUES ('gram' ,0)
INSERT INTO Jednostki (Jednostka_Nazwa, Jednostka_Mnoznik) VALUES ('mikrogram', -6)
INSERT INTO Jednostki (Jednostka_Nazwa, Jednostka_Mnoznik) VALUES ('dekagram', 1)
