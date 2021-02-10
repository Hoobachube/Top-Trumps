
# Users table
INSERT INTO Users(user_id, user_email, user_profile_name)
VALUES('1001', 'dachtler@live.co.uk', 'Hoobachube');
INSERT INTO Users(user_id, user_email, user_profile_name)
VALUES('1002', 'ragaflaffle@hotmail.com', 'Markie');
INSERT INTO Users(user_id, user_email, user_profile_name)
VALUES('1003', 'bwhite@aol.com', 'Big Barry');


# Cards table
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD001', 'White Lightning', 'Cider', 8.4, 2, 2, 6, 'English white cider produced from the 1990s to 2009. Discontinued due to its brand image problem in the UK becoming synonymous with under-age drinking, homelessness and alcoholism.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD002','Stella Artois','Belgian Pilsner', 5.2, 9, 4, 7, 'Originally launched as a Christmas beer, it has a well-balanced malt sweetness, crisp hop bitterness and dry finish. It has a generally unfounded perceived connection between binge drinking and domestic violence.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD003', 'Guinness', 'Irish Stout', 4.3, 8, 6, 9, 'First produced in, 1759. The draught features a characteristic tang and thick, creamy head. The Guinness Brewery in Dublin was the most popular tourist attraction in Ireland in 2017.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD004', 'Jack Daniels', 'Straight Bourbon', 40.0, 8, 6, 7, 'This bourbon has notes of sweet vanilla, caramel, toasty oak, smoke. The standard edition is quite inexpensive compared to other bourbons. It is generally considered by bourbon drinkers as one of the least refinded of its family.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD005', 'Fosters', 'Pale Lager', 4, 9, 7, 7, 'First brewed in Australia in 1889, but started mass production in England when the Courage obtained the rights to brew under the UK licence. Has a mild hoppy and malty flavour. It considered a middling and average lager.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD006', 'Gordons Gin', 'Dry Gin', 37.2, 8, 6, 9, 'First produced in 1769, the recipe has remained unchanged. It is triple-distilled and contains juniper berries, licorice, orange, and lemon. This gin is one of the most well known spirits on the planet and in turn is held in quite a high regard.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD007', 'Châteauneuf-du-Pape', 'Grenache Red Wine', 14.5, 6, 9, 8, 'This wine comes from Southern Rhône in France, it is known for a very concentrated mix of rich aromas and flavours of black cherry, plum and spices. Generally considered one of the nicest, more refined wines on a budget.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD008', 'Lambrini', 'Perry/Pear Cider', 3.5, 7, 3, 5, 'Although Lambrini is not a wine but a perry, it is a marketed more in the style of a wine than a traditional perry or cider. it has been associated with underage drinking, due to the cheap price and ABV.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD009', 'Wolf Blass Chardonnay', 'White Chardonnay Wine', 13.5, 8, 7, 7, 'This chardonnay is from South Australia, and was first produced by Wolfgang Blass AM in 1966 It is medium bodied wine with a soft, creamy texture.  Generally considered a good low budget chardonnay.');
INSERT INTO Cards(card_id, card_name, card_type, card_abv, card_accessibility, card_reputation, card_popularity, card_description)
VALUES('CD010', 'Strongbow', 'Dry Cider', 4.5, 9, 6, 7, 'Created in 1960 in the UK. In 2002 after a surge of new cider drinks arose its popularity dropped. Strongbow is a blend of bitter-sweet cider and culinary apples, with 50 different varieties of apple used.');


# Collection table
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1001', 'CD001', 1);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1001', 'CD002', 1);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1001', 'CD003', 0);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1001', 'CD004', 1);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1002', 'CD005', 0);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1002', 'CD006', 1);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1002', 'CD007', 1);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1003', 'CD008', 0);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1003', 'CD009', 1);
INSERT INTO Collection(user_id, card_id, in_deck)
VALUES('1003', 'CD010', 1);

# Games table
INSERT INTO Games(game_id, game_date, game_duration,game_winner)
VALUES('GA10001', '2021-01-28', 50000, 'Hoobachube');
INSERT INTO Games(game_id, game_date, game_duration,game_winner)
VALUES('GA10002', '2021-01-11', 50000, 'Big Barry');
INSERT INTO Games(game_id, game_date, game_duration, game_winner)
VALUES('GA10003', '2021-01-18', 42000, 'Markie');
INSERT INTO Games(game_id, game_date, game_duration,game_winner)
VALUES('GA10004', '2021-01-16', 27000, 'Hoobachube');
INSERT INTO Games(game_id, game_date, game_duration,game_winner)
VALUES('GA10005', '2021-01-05', 114000, 'Big Barry');
INSERT INTO Games(game_id, game_date, game_duration, game_winner)
VALUES('GA10006', '2021-01-31', 90000, 'Markie');


# Games_Vs_Users table
INSERT INTO Games_Vs_Users(game_id, user_id)
VALUES('GA10003', '1001');
INSERT INTO Games_Vs_Users(game_id, user_id)
VALUES('GA10001', '1003');
INSERT INTO Games_Vs_Users(game_id, user_id)
VALUES('GA10002', '1003');
