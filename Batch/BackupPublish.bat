@echo off
for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "YY=%dt:~2,2%" & set "YYYY=%dt:~0,4%" & set "MM=%dt:~4,2%" & set "DD=%dt:~6,2%"
set "HH=%dt:~8,2%" & set "Min=%dt:~10,2%" & set "Sec=%dt:~12,2%"

set "datestamp=%YYYY%%MM%%DD%" & set "timestamp=%HH%%Min%%Sec%"
set "fullstamp=%YYYY%-%MM%-%DD%_%HH%-%Min%-%Sec%"
echo datestamp: "%datestamp%"
echo timestamp: "%timestamp%"
echo fullstamp: "%fullstamp%"
REM got date now do backup


@echo backuping files
set backupDrive=\\sharedFolder\BackupPath
echo The variable is "%backupDrive%%date%"
@xcopy /j /c /y /s  \\sourcefolder\ %backupDrive%%fullstamp%\
pause

@echo Publishing
@xcopy /j /c /y /s /exclude:exclude.txt C:\From \\PublishFolder\Publish
@echo 
pause