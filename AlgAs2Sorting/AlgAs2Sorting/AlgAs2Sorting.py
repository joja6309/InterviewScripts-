import sys 
import os 
import random
# "C:\Users\Owner\Downloads\AlgAs2\shakespeare.txt"
# "C:\Users\Owner\Downloads\AlgAs2\wordlist.txt"

def main():
    print("success") 
    with open(@"C:\Users\Owner\Downloads\AlgAs2\shakespeare.txt", "r") as f:
        for line in f:
            for word in line.split():
                print(word)      

    

if __name__ == '__main__':

    main()