# msipermclean
Clean accidented files marked as permanent when creating setup projects in Visual studio

## Why?
I was creating a Setup project in Visual Studio. Somehow I marked "Content Output" and other files
as Permanent = True. This caused the files to not be removed during an uninstall.
This is because they are marked in the register as Permanent with the Value of Zeros and Data Is the filename.
So I created this to remove all occurences.

## Future
In future I will do this a little bit more generalized so you could use it on your projects too.
