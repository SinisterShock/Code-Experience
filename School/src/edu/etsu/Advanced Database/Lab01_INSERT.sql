Insert into location (StreetAddress, City, State, Zip) Values ('101 W Springbrook Dr','Johnson City','TN',37640); 
Insert into location (StreetAddress, City, State, Zip) Values ('130 Norman Station Blvd','Mooresville','NC',28117);
Insert into location (StreetAddress, City, State, Zip) Values ('2908 Gilmore Dr','Jonesboro','AR',72401);
Insert into location (StreetAddress, City, State, Zip) Values ('1674 Slabtown Rd','Mountain City','TN',37683);
Insert into location (StreetAddress, City, State, Zip) Values ('128 Circle View Dr','Mountain City','TN',37683);
Insert into location (StreetAddress, City, State, Zip) Values ('578 Clarence Potter Rd','Mountain City','TN',37683);

Insert into Hotel values ('01','Holiday Inn',3, '101 W Springbrook Dr');
Insert into Hotel values ('02','Holiday Inn',4, '130 Norman Station Blvd');
Insert into Hotel values ('03','Holiday Inn',4, '2908 Gilmore Dr');

Insert into Customer values('01','Tyler', 'Burleson', 1,'578 Clarence Potter Rd');
Insert into Customer values('02','Jacob', 'Creek', 0,'128 Circle View Dr');
Insert into Customer values('03','Michael', 'Jackson', 1,'1674 Slabtown Rd');

Insert into room values(104, 0, 2, 4, '01', '01', to_date('2022-08-10', 'yyyy-mm-dd'), to_date('2022-08-15', 'yyyy-mm-dd'));
Insert into room values(314, 0, 1, 2, '03', '02', to_date('2022-11-13', 'yyyy-mm-dd'), to_date('2022-11-15', 'yyyy-mm-dd'));
Insert into room values(224, 0, 2, 4, '02', '03', to_date('2022-12-22', 'yyyy-mm-dd'), to_date('2022-12-19', 'yyyy-mm-dd'));

insert into rate values('2', '54.00', '2 Bed one bath family suite', 'Standard Condition', 104);
insert into rate values('1', '45.00', '1 Bed one bath couple suite', 'Poor Condition', 314);
insert into rate values('2', '99.00', '2 Bed one bath Platnium suite', 'Premium Condition', 224);
