Select hotel.name as "Hotel Name", hotel.rating as "Hotel Rating", hotel.streetaddress as "Hotel Address", location.zip as "Hotel Zip", 
location.city as "Hotel City", location.state as "Hotel State" from hotel
join location on hotel.streetaddress = location.streetaddress order by location.state, location.city;

select concat(concat(customer.lastname, ' '), customer.firstname) as "Customer Name (Last, First)", 
hotel.name as "Hotel Name", room.roomnumber as "Room Number", room.beds as "Beds", room.Maximumguest as "Max Guest" from customer
join room on room.currentcustomer = customer.customerid join hotel on hotel.hotelid = room.hotelid order by customer.lastname, hotel.name, room.roomnumber;