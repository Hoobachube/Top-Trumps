CREATE TABLE Users (
    user_id CHAR(10) NOT NULL,
    user_email CHAR(255) NOT NULL,
    user_profile_name CHAR(10) NOT NULL
);

CREATE TABLE Collection (
    user_id CHAR(10) NOT NULL,
    card_id CHAR(10) NOT NULL,
    in_deck tinyint(1) NOT NULL
);

CREATE TABLE Cards (
    card_id CHAR(10) NOT NULL,
    card_name CHAR(100) NOT NULL,
    card_type CHAR(30) NOT NULL,
    card_abv DECIMAL(3,1) NOT NULL,
    card_accessibility INT NOT NULL,
    card_reputation INT NOT NULL,
    card_popularity INT NOT NULL,
    card_description CHAR(255) NOT NULL
);

CREATE TABLE Games (
    game_id CHAR(10) NOT NULL,
    game_date DATE NULL,
    game_duration INT NULL,
    game_winner CHAR(10) NULL
);

CREATE TABLE Games_Vs_Users (
    game_id CHAR(10) NOT NULL,
    user_id CHAR(10) NOT NULL
);

ALTER TABLE Users ADD PRIMARY KEY (user_id);
ALTER TABLE Collection ADD PRIMARY KEY (user_id, card_id);
ALTER TABLE Cards ADD PRIMARY KEY (card_id);
ALTER TABLE Games ADD PRIMARY KEY (game_id);
ALTER TABLE Games_Vs_Users ADD PRIMARY KEY (game_id, user_id);

ALTER TABLE collection ADD FOREIGN KEY (user_id) REFERENCES users (user_id);
ALTER TABLE Games_Vs_Users ADD FOREIGN KEY (user_id) REFERENCES Users (user_id);
ALTER TABLE Games_Vs_Users ADD FOREIGN KEY (game_id) REFERENCES games (game_id);
ALTER TABLE Collection ADD FOREIGN KEY (card_id) REFERENCES cards (card_id);
