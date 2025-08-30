
--REM: OPTION B (MariaDB compatible)
--REM: Simple students-only table. App generates IDs (GUID/UUID) and inserts them.

CREATE DATABASE IF NOT EXISTS `brief_crud`
  DEFAULT CHARACTER SET = utf8mb4
  DEFAULT COLLATE = utf8mb4_unicode_ci;
USE `brief_crud`;

CREATE TABLE IF NOT EXISTS `students` (
  `id` CHAR(36) NOT NULL PRIMARY KEY,     --REM: UUID as text (36 chars)
  `first_name` VARCHAR(50) NOT NULL,
  `last_name` VARCHAR(50) NOT NULL,
  `middle_name` VARCHAR(50),
  `gender` ENUM('MALE','FEMALE','OTHER') NOT NULL,
  `dob` DATE NOT NULL,
  `course` VARCHAR(100) NOT NULL,         --REM: free-form course text
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  CHECK (dob <= CURRENT_DATE())           --REM: may be ignored on older MariaDB; trigger below enforces it
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;

--REM: Add useful indexes (ALTER TABLE syntax works on MariaDB)
ALTER TABLE `students`
  ADD INDEX `idx_students_lastname` (`last_name`),
  ADD INDEX `idx_students_dob` (`dob`);

--REM: If your MariaDB version does not enforce CHECK, create triggers to enforce DOB rule:
--REM: (DELIMITER usage required when running in a client that supports it)

DELIMITER $$
CREATE TRIGGER trg_students_before_insert
BEFORE INSERT ON `students`
FOR EACH ROW
BEGIN
  IF NEW.dob > CURDATE() THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'DOB cannot be in the future';
  END IF;
END$$

CREATE TRIGGER trg_students_before_update
BEFORE UPDATE ON `students`
FOR EACH ROW
BEGIN
  IF NEW.dob > CURDATE() THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'DOB cannot be in the future';
  END IF;
END$$
DELIMITER ;

--REM: Example insertion (application supplies GUID)
INSERT INTO students (id, first_name, last_name, middle_name, gender, dob, course)
VALUES ('25-BSIT-0001','FYep','LYap','MYo','MALE','2000-01-28','BSIT');
