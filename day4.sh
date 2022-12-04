#!/bin/bash

count () {
sed 's|^\(.*\)-\(.*\),\(.*\)-\(.*\)$|(\1<=\3)+(\2>=\4)+(((\3<=\1)+(\4>=\2))*10)+(((\1<=\4)+(\2>=\3))*300)|' /tmp/aoc/input | bc | grep $1 | wc -l
}

echo "Task 1 $(count 2)"
echo "Task 2 $(count 6)"