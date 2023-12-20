@echo off

REM Compiles .tex file in current directory to .pdf using pdflatex compiler

REM Set file name
set fileName="x-IMU User Manual"

REM Remove intermediate files
call:cleanup

REM Compile .tex to .dvi
set miktex="C:\Progra~2\MiKTeX 2.9\miktex\bin"
%miktex%\pdflatex.exe %fileName%
%miktex%\bibtex.exe %fileName%
%miktex%\pdflatex.exe %fileName%
%miktex%\pdflatex.exe %fileName%

REM Remove intermediate files
call:cleanup

REM Open pdf
START "C:\Progra~2\Adobe\Reader 9.0\Reader\AcroRd32.exe" ""%fileName%.pdf""

REM Clean up function
:cleanup
del ""%fileName%.aux""
del ""%fileName%.bbl""
del ""%fileName%.blg""
del ""%fileName%.brf""
del ""%fileName%.dvi""
del ""%fileName%.lof""
del ""%fileName%.log""
del ""%fileName%.lot""
del ""%fileName%.out""
del ""%fileName%.spl""
del ""%fileName%.toc""
goto:eof
