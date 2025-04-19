CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE IF NOT EXISTS pictures(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  url VARCHAR(255) COMMENT 'Picture URL',
  album_id INT NOT NULL COMMENT 'Album ID',
creator_id VARCHAR(255) NOT NULL COMMENT 'Creator ID',
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE ,
  FOREIGN KEY (album_id) REFERENCES albums(id) ON DELETE CASCADE
)

CREATE TABLE IF NOT EXISTS albums(
 id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) NOT NULL COMMENT 'Album Name',
description TEXT COMMENT 'Album Description',
isArchived BOOLEAN NOT NULL DEFAULT false COMMENT 'Is Archived',
category ENUM(
    'aesthetics',
    'games',
    'animals',
    'food',
    'vibes',
    'misc'
),
cover_img TEXT NOT NULL COMMENT 'Cover Image',
creator_id VARCHAR(255) NOT NULL COMMENT 'Creator ID',
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE
)

 DROP TABLE watcher;
DROP TABLE pictures;
 DROP TABLE albums;


 CREATE TABLE watcher(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
account_id VARCHAR(255) NOT NULL COMMENT 'Account ID',
album_id VARCHAR(255) NOT NULL COMMENT 'Album ID',
  FOREIGN KEY (account_id) REFERENCES accounts(id) ON DELETE CASCADE ,
  FOREIGN KEY (album_id) REFERENCES albums(id) ON DELETE CASCADE
 )



INSERT INTO
    albums (
        title,
        description,
        coverImage,
        creator_id,
        category,
        isArchived
    )
VALUES (
        'cool car games',
        'This is really cool car games',
        'https://plus.unsplash.com/premium_photo-1682125845754-9a4b0d77a66a?q=80&w=2671&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
        '66d109c1258b754bca428053',
        'games',
        false
    );

INSERT INTO picture
(
    url,
    album_id,
    creator_id
)
VALUES (
    'https://plus.unsplash.com/premium_photo-1682125845754-9a4b0d77a66a?q=80&w=2671&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
    '1',
    '66d109c1258b754bca428053'
);