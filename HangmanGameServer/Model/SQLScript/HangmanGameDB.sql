
-- Nombre de la base de datos
DECLARE @DatabaseName NVARCHAR(128) = N'HangmanGameDB';

-- Verificar si la base de datos existe
IF EXISTS (SELECT name FROM sys.databases WHERE name = @DatabaseName)
BEGIN
	-- Cerrar conexiones a la base de datos
    ALTER DATABASE [HangmanGameDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

    -- Eliminar la base de datos
    DROP DATABASE [HangmanGameDB];
END;

-- Crear la base de datos
CREATE DATABASE [HangmanGameDB];
GO

-- Usar la nueva base de datos
USE [HangmanGameDB];
GO

-- Crear tabla Account
CREATE TABLE Account (
    id_account INT PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);
GO

-- Crear tabla Person
CREATE TABLE Person (
    id_person INT PRIMARY KEY IDENTITY(1,1),
    id_account INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    date_of_birth DATE NOT NULL,
    phone_number VARCHAR(10) NOT NULL,
    CONSTRAINT FK_Person_Account FOREIGN KEY (id_account) REFERENCES Account(id_account)
);
GO

-- Crear tabla Score
CREATE TABLE Score (
    id_score INT PRIMARY KEY IDENTITY(1,1),
    id_person INT NOT NULL,
    score INT DEFAULT 0,
    CONSTRAINT FK_Score_Person FOREIGN KEY (id_person) REFERENCES Person(id_person)
);
GO

-- Crear tabla Category
CREATE TABLE Category (
    id_category INT PRIMARY KEY IDENTITY(1,1),
    category_name_english VARCHAR(255) NOT NULL,
    category_name_spanish VARCHAR(255) NOT NULL
);
GO

-- Crear tabla Phrase
CREATE TABLE Phrase (
    id_phrase INT PRIMARY KEY IDENTITY(1,1),
    id_category INT NOT NULL,
    phrase_english VARCHAR(1000) NOT NULL,
    hint_english VARCHAR(5000) NOT NULL,
    phrase_spanish VARCHAR(1000) NOT NULL,
    hint_spanish VARCHAR(5000) NOT NULL,
    CONSTRAINT FK_Phrase_Category FOREIGN KEY (id_category) REFERENCES Category(id_category)
);
GO

-- Crear tabla de enum GameStatus
CREATE TABLE GameStatus (
    id_game_status INT PRIMARY KEY IDENTITY(1,1),
	game_status VARCHAR(50) NOT NULL,
);
GO

-- Crear tabla de enum GameLanguage
CREATE TABLE GameLanguage (
    id_game_language INT PRIMARY KEY IDENTITY(1,1),
	game_language VARCHAR(50) NOT NULL,
);
GO

-- Crear tabla Game
CREATE TABLE Game (
    id_game INT PRIMARY KEY IDENTITY(1,1),
    id_initiator INT NOT NULL,
    id_challenger INT NULL,
    phrase INT NOT NULL,
    creation_date DATETIME NULL,
    winner INT NULL,
	game_status INT NOT NULL,
	game_language INT NOT NULL,
    CONSTRAINT FK_Game_Initiator FOREIGN KEY (id_initiator) REFERENCES Account(id_account),
    CONSTRAINT FK_Game_Challenger FOREIGN KEY (id_challenger) REFERENCES Account(id_account),
    CONSTRAINT FK_Game_Phrase FOREIGN KEY (phrase) REFERENCES Phrase(id_phrase),
    CONSTRAINT FK_Game_Winner FOREIGN KEY (winner) REFERENCES Account(id_account),
	CONSTRAINT FK_Game_Status FOREIGN KEY (game_status) REFERENCES GameStatus(id_game_status),
	CONSTRAINT FK_Game_Language FOREIGN KEY (game_language) REFERENCES Gamelanguage(id_game_language),
);
GO

-- Crear tabla Turn
CREATE TABLE Turn (
    id_turn INT PRIMARY KEY IDENTITY(1,1),
	id_game INT NOT NULL,
	word VARCHAR(1) NOT NULL,
	remaining_attempts INT NOT NULL,
	CONSTRAINT FK_Turn_Game FOREIGN KEY (id_game) REFERENCES Game(id_game),
);
GO

INSERT INTO GameStatus (game_status) VALUES
('ACTIVE'),
('IN PLAY'),
('FINISHED'),
('DELETED'),
('ABANDONED');
GO

INSERT INTO GameLanguage(game_language) VALUES
('ENGLISH'),
('SPANISH');
GO

-- Llenar la tabla Category
INSERT INTO Category (category_name_english, category_name_spanish)
VALUES 
('Animals', 'Animales'),
('Foods', 'Comidas'),
('Countries', 'Países'),
('Objects', 'Objetos'),
('Famous People', 'Personas Famosas');
GO

-- Llenar la tabla Phrase
INSERT INTO Phrase (id_category, phrase_english, hint_english, phrase_spanish, hint_spanish)
VALUES
-- Animals (id_category = 1)
(1, 'ELEPHANT', 'A large mammal with a trunk', 'ELEFANTE', 'Un gran mamífero con una trompa'),
(1, 'GIRAFFE', 'An animal with a very long neck', 'JIRAFA', 'Un animal con un cuello muy largo'),
(1, 'TIGER', 'A large feline with stripes', 'TIGRE', 'Un gran felino con rayas'),
(1, 'ARMADILLO', 'A small mammal with a hard shell', 'ARMADILLO', 'Un pequeño mamífero con un caparazón duro'),
(1, 'FLAMINGO', 'A bird with pink feathers and long legs', 'FLAMENCO', 'Un ave con plumas rosas y piernas largas'),
(1, 'KANGAROO', 'A marsupial from Australia', 'CANGURO', 'Un marsupial de Australia'),
-- Foods (id_category = 2)
(2, 'RATATOUILLE', 'A French Provençal stewed vegetable dish', 'RATATOUILLE', 'Un guiso de verduras provenzal francés'),
(2, 'BURRITO', 'A Mexican dish with a flour tortilla wrapped around fillings', 'BURRITO', 'Un plato mexicano con una tortilla de harina alrededor de rellenos'),
(2, 'CROISSANT', 'A flaky, buttery French pastry', 'CROISSANT', 'Un hojaldre francés mantecoso'),
(2, 'PAELLA', 'A Spanish rice dish with seafood or meat', 'PAELLA', 'Un plato de arroz español con mariscos o carne'),
(2, 'CHURROS', 'A fried-dough pastry-based snack', 'CHURROS', 'Un bocadillo a base de masa frita'),
(2, 'CEVICHE', 'A South American dish of marinated raw fish or seafood', 'CEVICHE', 'Un plato sudamericano de pescado o marisco crudo marinado'),
-- Countries (id_category = 3)
(3, 'BRAZIL', 'The largest country in South America', 'BRASIL', 'El país más grande de América del Sur'),
(3, 'NEPAL', 'A country in the Himalayas known for Mount Everest', 'NEPAL', 'Un pais en el Himalaya conocido por el Monte Everest'),
(3, 'INDIA', 'A country with the Taj Mahal', 'INDIA', 'Un país con el Taj Mahal'),
(3, 'MADAGASCAR', 'An island country in the Indian Ocean, off the coast of East Africa', 'MADAGASCAR', 'Un país insular en el Océano Índico, frente a la costa de África Oriental'),
(3, 'LUXEMBOURG', 'A small, wealthy country in Western Europe', 'LUXEMBURGO', 'Un pequeño y rico país en Europa Occidental'),
(3, 'MALDIVES', 'An island nation in the Indian Ocean', 'MALDIVAS', 'Una nación insular en el Océano Índico'),
-- Objects (id_category = 4)
(4, 'ASTROLABE', 'An ancient instrument used to make astronomical measurements', 'ASTROLABIO', 'Un antiguo instrumento utilizado para hacer mediciones astronómicas'),
(4, 'TELESCOPE', 'An instrument used to observe distant objects', 'TELESCOPIO', 'Un instrumento utilizado para observar objetos distantes'),
(4, 'KALEIDOSCOPE', 'A toy that creates patterns through reflection', 'CALEIDOSCOPIO', 'Un juguete que crea patrones a través de la reflexión'),
(4, 'PERISCOPE', 'An instrument for observation from a concealed position', 'PERISCOPIO', 'Un instrumento para observación desde una posición oculta'),
(4, 'MICROSCOPE', 'An instrument used to view very small objects', 'MICROSCOPIO', 'Un instrumento utilizado para ver objetos muy pequeños'),
(4, 'GLOBE', 'A spherical representation of the Earth', 'GLOBO', 'Una representación esférica de la Tierra'),
-- Famous People (id_category = 5)
(5, 'DARWIN', 'A naturalist known for the theory of evolution', 'DARWIN', 'Un naturalista conocido por la teoria de la evolucion'),
(5, 'SHAKESPEARE', 'A famous English playwright and poet', 'SHAKESPEARE', 'Un famoso dramaturgo y poeta inglés'),
(5, 'GALILEO', 'An Italian astronomer and physicist who championed heliocentrism', 'GALILEO', 'Un astrónomo y físico italiano que defendió el heliocentrismo'),
(5, 'CURIE', 'A physicist and chemist who conducted pioneering research on radioactivity', 'CURIE', 'Una física y química que realizó investigaciones pioneras sobre la radiactividad'),
(5, 'ADA LOVELACE', 'An English mathematician who worked on the early mechanical general-purpose computer', 'ADA LOVELACE', 'Una matemática inglesa que trabajó en la primera computadora mecánica de propósito general'),
(5, 'TESLA', 'A Serbian-American inventor known for his contributions to the design of the modern alternating current electricity supply system', 'TESLA', 'Un inventor serbo-estadounidense conocido por sus contribuciones al diseño del sistema moderno de suministro eléctrico de corriente alterna');
GO