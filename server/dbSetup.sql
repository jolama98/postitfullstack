CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE picture(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  url VARCHAR(255)NOT NULL COMMENT 'Picture URL',
  album_id VARCHAR(255)NOT NULL COMMENT 'Album ID',
creator_id VARCHAR(255) NOT NULL COMMENT 'Creator ID',
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE ,
  FOREIGN KEY (album_id) REFERENCES albums(id) ON DELETE CASCADE 
)

CREATE TABLE albums(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) NOT NULL COMMENT 'Album Name',
description VARCHAR(255) NOT NULL COMMENT 'Album Description',
isArchived BOOLEAN NOT NULL DEFAULT false COMMENT 'Is Archived',
category ENUM(
    'aesthetics',
    'games',
    'animals',
    'food',
    'vibes',
    'misc'
),
coverImage VARCHAR(255) NOT NULL COMMENT 'Cover Image',
creator_id VARCHAR(255) NOT NULL COMMENT 'Creator ID',
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE
)

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

 insert into picture( url, album_id, creator_id) values('https://plus.unsplash.com/premium_photo-1682125845754-9a4b0d77a66a?q=80&w=2671&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',1,'66d109c1258b754bca428053')