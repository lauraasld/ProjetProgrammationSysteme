/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: CategoryType
------------------------------------------------------------*/
CREATE TABLE CategoryType(
	id           INT IDENTITY (1,1) NOT NULL ,
	name         VARCHAR (255) NOT NULL ,
	time_alive   INT  NOT NULL  ,
	CONSTRAINT CategoryType_PK PRIMARY KEY (id)
);


/*------------------------------------------------------------
-- Table: ProductList
------------------------------------------------------------*/
CREATE TABLE ProductList(
	id                INT IDENTITY (1,1) NOT NULL ,
	name              VARCHAR (255) NOT NULL ,
	id_CategoryType   INT  NOT NULL  ,
	CONSTRAINT ProductList_PK PRIMARY KEY (id)

	,CONSTRAINT ProductList_CategoryType_FK FOREIGN KEY (id_CategoryType) REFERENCES CategoryType(id)
);


/*------------------------------------------------------------
-- Table: Storage
------------------------------------------------------------*/
CREATE TABLE Storage(
	id               INT IDENTITY (1,1) NOT NULL ,
	arrivalDate      DATETIME NOT NULL ,
	amount           INT  NOT NULL ,
	id_ProductList   INT  NOT NULL  ,
	CONSTRAINT Storage_PK PRIMARY KEY (id)

	,CONSTRAINT Storage_ProductList_FK FOREIGN KEY (id_ProductList) REFERENCES ProductList(id)
);



