create table if not exists Pallets(
	Id integer primary key autoincrement,
	Width integer not null,
	Height integer not null,
	Depth integer not null,
	constraint Dimensions check(Width > 0 and Height > 0 and Depth > 0)
);

create table if not exists Boxes(
	Id integer primary key autoincrement,
	Width integer not null,
	Height integer not null,
	Depth integer not null,
	Weight integer not null,
	Date text not null,
	IsExpirationDate integer not null,
	PalletId integer not null,
	constraint Dimensions check(Width > 0 and Height > 0 and Depth > 0)
	constraint Weight check(Weight > 0),
	foreign key(PalletId) references Pallets(Id) on delete cascade
);

create trigger if not exists check_box_dimensions_insert
before insert on Boxes
for each row
begin
	select case
		when (select Width from Pallets where id = new.PalletId) < new.Width then
			raise(abort, 'Box width cannot exceed pallet width')
		when (select Depth from Pallets where id = new.PalletId) < new.Depth then
			raise(abort, 'Box depth cannot exceed pallet depth')
	end;
end;

create trigger if not exists check_box_dimensions_update
before update of Width, Depth on Boxes
for each row
begin
	select case
		when (select Width from Pallets where id = new.PalletId) < new.Width then
			raise(abort, 'Box width cannot exceed pallet width')
		when (select Depth from Pallets where id = new.PalletId) < new.Depth then
			raise(abort, 'Box depth cannot exceed pallet depth')
	end;
end;

create trigger if not exists check_box_dimensions_pallet_update
before update of Width, Depth on Pallets
for each row
begin
	select case
		when exists (
			select 1 from Boxes 
			where PalletId = new.Id
			and (Width > new.Width or Depth > new.Depth)
		) then
			raise(abort, 'Cannot resize pallet as boxes would no longer fit')
	end;
end;