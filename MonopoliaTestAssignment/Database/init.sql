create table if not exists Pallets(
	Id integer primary key autoincrement,
	Width integer not null,
	Height integer not null,
	Depth integer not null,
	constraint Width check(Width > 0),
	constraint Height check(Width > 0),
	constraint Depth check(Width > 0)
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
	constraint Width check(Width > 0),
	constraint Height check(Width > 0),
	constraint Depth check(Width > 0),
	constraint Weight check(Weight > 0),
	foreign key PalletId references Pallets(Id)
);

create trigger if not exists check_box_dimensions_insert
before insert on Boxes
begin
	select case
		when (select Width from Pallets where id = new.PalletId) < new.Width then
			raise(abort, 'Box width cannot exceed pallet width')
		when (select Depth from Pallets where id = new.PalletId) < new.Depth then
			raise(abort, 'Box depth cannot exceed pallet depth')
	end;
end;

--TODO update triggers