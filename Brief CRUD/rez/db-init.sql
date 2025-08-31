CREATE DATABASE IF NOT EXISTS `brief_crud`
  DEFAULT CHARACTER SET = utf8mb4
  DEFAULT COLLATE = utf8mb4_unicode_ci;
USE `brief_crud`;

CREATE TABLE IF NOT EXISTS `students` (
  `id` CHAR(36) NOT NULL PRIMARY KEY,   
  `first_name` VARCHAR(50) NOT NULL,
  `last_name` VARCHAR(50) NOT NULL,
  `middle_name` VARCHAR(50),
  `gender` ENUM('MALE','FEMALE','OTHER') NOT NULL,
  `dob` DATE NOT NULL,
  `course` VARCHAR(100) NOT NULL,         
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;

ALTER TABLE `students`
  DROP INDEX IF EXISTS `idx_students_lastname`,
  DROP INDEX IF EXISTS `idx_students_dob`,
  ADD INDEX `idx_students_lastname` (`last_name`),
  ADD INDEX `idx_students_dob` (`dob`);

DROP TRIGGER IF EXISTS `trg_students_before_insert`;
DROP TRIGGER IF EXISTS `trg_students_before_update`;

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

INSERT INTO students (id, first_name, last_name, middle_name, gender, dob, course)
VALUES ('25-BSIT-0001','FYes','LYeah','MYo','MALE','2000-01-28','BSIT');