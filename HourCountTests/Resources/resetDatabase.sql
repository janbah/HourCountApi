DELETE FROM hour_count_test.dbo.working_time;
DELETE FROM hour_count_test.dbo.project;
DELETE FROM hour_count_test.dbo.employee;
DELETE FROM hour_count_test.dbo.customer;
DELETE FROM hour_count_test.dbo.fair;

INSERT INTO hour_count_test.dbo.fair (id, name, town, start_date, end_date, long_name) VALUES (1, N'HMI', N'Hannover', N'2022-01-01 00:00:00.0000000', N'2022-01-05 00:00:00.0000000', N'Hannover Messe Industrie');
INSERT INTO hour_count_test.dbo.fair (id, name, town, start_date, end_date, long_name) VALUES (2, N'Automechanica', N'Frankfurt', N'2022-02-01 00:00:00.0000000', N'2022-02-05 00:00:00.0000000', N'');
INSERT INTO hour_count_test.dbo.fair (id, name, town, start_date, end_date, long_name) VALUES (3, N'Hi-Tech', N'Dortmund', N'2022-03-01 00:00:00.0000000', N'2022-03-05 00:00:00.0000000', N'');

INSERT INTO hour_count_test.dbo.customer (id, name, long_name) VALUES (1, N'Cust 1', N'Customer 1');
INSERT INTO hour_count_test.dbo.customer (id, name, long_name) VALUES (2, N'Cust 2', N'Customer 3');
INSERT INTO hour_count_test.dbo.customer (id, name, long_name) VALUES (3, N'Cust 3', N'Customer 3');
INSERT INTO hour_count_test.dbo.customer (id, name, long_name) VALUES (4, N'Cust 4', N'Customer 4');

INSERT INTO hour_count_test.dbo.employee (id, name, is_active) VALUES (1, N'Martin', 1);
INSERT INTO hour_count_test.dbo.employee (id, name, is_active) VALUES (2, N'Bill', 1);
INSERT INTO hour_count_test.dbo.employee (id, name, is_active) VALUES (3, N'Sandra', 1);
INSERT INTO hour_count_test.dbo.employee (id, name, is_active) VALUES (4, N'Jane', 0);

INSERT INTO hour_count_test.dbo.project (id, customer_id, fair_id, start_date, end_date) VALUES (1, 1, 1, N'2022-01-01 00:00:00.0000000', N'2022-12-31 00:00:00.0000000');
INSERT INTO hour_count_test.dbo.project (id, customer_id, fair_id, start_date, end_date) VALUES (2, 2, 2, N'2022-01-01 00:00:00.0000000', N'2022-12-31 00:00:00.0000000');

SET IDENTITY_INSERT hour_count_test.dbo.working_time ON
INSERT INTO hour_count_test.dbo.working_time (id, time_entry, employee_id, project_id, category_id, comment, date) VALUES (1, 1, 1, 1, 1, N'test 1', N'2022-12-14 00:00:00.0000000');
INSERT INTO hour_count_test.dbo.working_time (id, time_entry, employee_id, project_id, category_id, comment, date) VALUES (2, 2, 1, 2, 1, N'test 2', N'2022-12-14 00:00:00.0000000');
INSERT INTO hour_count_test.dbo.working_time (id, time_entry, employee_id, project_id, category_id, comment, date) VALUES (3, 3, 1, 2, 2, N'test 3', N'2022-12-14 00:00:00.0000000');
INSERT INTO hour_count_test.dbo.working_time (id, time_entry, employee_id, project_id, category_id, comment, date) VALUES (4, 4, 1, 2, 2, N'test 3', N'2022-12-15 00:00:00.0000000');
SET IDENTITY_INSERT hour_count_test.dbo.working_time OFF