echo off

rem batch file to run a script to create a db
rem 10/21/2016

sqlcmd -S localhost -E -i stutorDB.sql

ECHO if no error messages appear DB was created
PAUSE