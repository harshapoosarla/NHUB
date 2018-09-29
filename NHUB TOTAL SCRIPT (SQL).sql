--create database NotificationHub

select *from AspNetUsers

select *from AspNetUserRoles

select *from AspNetRoles

insert into AspNetRoles values(4,'End User')

insert into AspNetUserRoles values('5bb767e5-b5a5-4568-94a2-f2268b57cd58',1);
insert into AspNetUserRoles values('b55dd792-4b2e-498b-a4f4-2296b31ff6a0',2);
insert into AspNetUserRoles values('1184de1d-ee2a-489a-b64c-6e2543624f9e',3);
insert into AspNetUserRoles values('f45b41f4-091a-4fbe-aefa-260208647cba',4);


create table Source
(
	Id int identity(1,1) primary key,
	Name varchar(50) not null,
)

create table Event
(
	Id int identity(1,1) primary key,
	Name varchar(50) not null,
	SourceId int foreign key references Source(id),
	Mandatory bit
)

create table Channel
(
	Id int identity(1,1) primary key,
	Name varchar(50) not null
)

create table EventChannel
(
	EventId int foreign key references Event(id),
	ChannelId int foreign key references Channel(id)
)



create table Datatype
(
	Id int identity(1,1) primary key,
	Name varchar(50)
)

create table EventSourceFields
(
	EventId int foreign key references Event(id),
	SourceFieldName varchar(50) not null,
	dataTypeId int foreign key references Datatype(Id),
	UniqueAlias varchar(50)
)

Create table ServiceLine
(
	Id int primary key identity(1,1),
	Name nvarchar(50)
)

select * from ServiceLine



insert into ServiceLine values()

Create table ServiceLineManager
(
	Id int primary key identity(1,1), 
	ServiceLineId int foreign key references ServiceLine(Id),
	UserId nvarchar(128) foreign key references AspNetUsers(Id)
) 

Create table Event_slm_subscribe
(	Id int primary key identity(1,1), 
	EventId int foreign key references Event(Id),
	ServiceLineId int foreign key references ServiceLine(Id),
	ServiceLineManagerId int foreign key references ServiceLineManager(Id),
	Confidential bit ,Mandatory bit  
)

Create table Event_slm_subscribe_users
 (		
	Event_slm_subscribe_Id int foreign key references Event_slm_subscribe(Id),
	UserId nvarchar(128) foreign key references AspNetUsers(Id) 
)

Create table Event_slm_subscribe_channel
(
	Event_slm_subscribe_Id int foreign key references Event_slm_subscribe(Id),
	ChannelId int foreign key references Channel(Id)  
)

Create table OperationManager
(  
	OperationManagerId nvarchar(128) foreign key references AspNetUsers(Id),
	ServicelineId int foreign key references ServiceLine(Id) 
)	

Create table Template
( 
	Id int  identity(1,1) primary key,
	Name nvarchar(50),
	OperationManagerId nvarchar(128) foreign key references AspNetUsers(Id),
	ServiceLineId int foreign key references ServiceLine(Id),
	EventId int foreign key references Event(Id)
)

 Create table ApprovalStatus
( 
	Id int  identity(1,1) primary key, 
	Name nvarchar(50) 
)

Create table TemplateChannel
( 
	TemplateId int  foreign key references Template(Id), 
	ChannelId int foreign key references channel(Id),
	Url nvarchar(500),
	ApprovalStatusId int foreign key references ApprovalStatus(Id)
)

create table MyEvents
(
	UserId nvarchar(128) foreign key references AspNetUsers(Id),
	EventId int foreign key references Event(Id),
	Subscribed bit
)

Create table MyEventsChannel
(	
	UserId nvarchar(128) foreign key references AspNetUsers(Id),
	EvenetId int foreign key references Event(Id),
	Channelid int foreign key references Channel(Id) 
)



------------------proc for select
create procedure selectproc 
(@Action varchar(10))
as begin
set nocount on;
--select
if @Action= 'SELECT'
begin
select * from ServiceLine;
end
end

------------------proc for insert

create or alter procedure Proc_InsertServiceLine
 (@pServLineName nvarchar(50),@pSLMids varchar(500))

 as
 begin
 set nocount on;
begin transaction; 

insert into ServiceLine(Name) values(@pServLineName);
declare  @ServLineId int;
 select @ServLineId=id from  ServiceLine where Name=@pServLineName;
 
end
end



select u.UserName,r.Name,u.Id from AspNetUserRoles ur join AspNetUsers u on ur.UserId=u.Id 
								join AspNetRoles r on r.Id=ur.RoleId and r.Name='ServiceLine Manager'


