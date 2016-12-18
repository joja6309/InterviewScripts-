import sys 
import os 
import random
import string 
import math 

class Player(object):
        def __init__(self, firstname, lastname, club,  letter_rank,year_rank):
            self.Firstname = firstname
            self.Lastname = lastname 
            self.Club = club 
            self.Letter = letter_rank
            self.Year = year_rank
            self.UniqueSum = 0 
            self.PoolNumber = 0 

class Pool(object): 
    def __init__(self):
        self.size = 0
        self.player_list = []
        self.club_list = []
# Rules 
# Largest pool size = Smallest pool size <= 1 
# Optimum size 6 or 7 then 7 or 8 then 5 or 6 
# Minimize Club memebrship within each pool     
class Tournament(object): 
        def __init__(self, listOfPlayers): 
            self.PlayerList = listOfPlayers
            self.NumberOfPlayers = len(listOfPlayers)
            self.DictionaryOfPools = {}
            self.DictionaryOfClubs = {} 
        def OrganizeOnnumberRank(self):
            self.SumYearAndRank()
            for key in self.DictionaryOfClubs.keys():
                for player_list in self.DictionaryOfClubs[key]:
                    player_list.sort(key = lambda c: c.UniqueSum)
        def SumYearAndRank(self): 
            di=dict(zip(string.ascii_uppercase,[ord(c)%32 for c in string.ascii_uppercase]))
            for key in self.DictionaryOfClubs.keys():
                for player in self.DictionaryOfClubs[key]: 
                    number_rank = int(player.Year) 
                    number_alpha = di[player.Letter]
                    player.UniqueSum = number_rank + number_alpha
        def BuildDictionaryOfClubs(self): 
            for player in self.PlayerList: 
                if (player.Club in self.DictionaryOfClubs.keys()):
                    self.DictionaryOfClubs[player.Club].append(player) 
                else: 
                    new_list = list()
                    new_list.append(player) 
                    self.DictionaryOfClubs[player.Club] = new_list 
            return
        def BuildTournament(self):
            self.BuildDictionaryOfClubs()
            self.SumYearAndRank()
            pool_count = 1; 
            first_pool = Pool()
            self.DictionaryOfPools[pool_count] = first_pool

            while(True):
                temp_pool = Pool()
                for key in self.DictionaryOfClubs.keys():
                    if(len(self.DictionaryOfClubs[key]) == 0) 
                        del self.DictionaryOfClubs[key]
                        
                    if (key in temp_pool.club_list):
                            pass
                    else:
                        player_to_move = self.DictionaryOfClubs[key].pop() 
                        temp_pool.club_list.append(key)
                        temp_pool.player_list.append()
                        temp_pool.size += 1
                if (temp_pool.size >= 7) 
                    self.DictionaryOfPools[pool_count] = temp_pool
                    pool_count+=1 
                    temp_pool = Pool()
                elif 

                        
                            
                            


                        
                    
          #index = 0 
          #  pool_count = 1 
          #  temp_pool = []
          #  dist_list = self.PlayerList
                

            
            #while(len(dist_list) != 0 ):
            #    if(len(temp_pool) < 6 ):
            #        temp_pool.append(dist_list.pop())
            #    elif (len(dist_list) < 6):
            #        self.DictionaryOfPools[pool_count] = temp_pool 
            #        pool_count+=1
            #        temp_pool = []
            #        self.DictionaryOfPools[pool_count] = dist_list 
            #        break
            #    else:
            #        self.DictionaryOfPools[pool_count] = temp_pool 
            #        pool_count+=1
            #        temp_pool = []


            #self.DistributeClubMembers()
            




            #for pool in self.DictionaryOfPools.keys(): 
            #    print("Pool Number" + str(pool))
            #    print("=========================") 
            #    for player in self.DictionaryOfPools[pool]: 
            #        print(player.Firstname) 
            #        print(player.UniqueSum) 
            #        print(player.Club) 



            #start_number_of_pools = len(self.DictionaryOfPools.keys())
            #list_of_keys =  list(self.DictionaryOfPools.keys())
            #list_of_keys.sort(reverse = True) 

            #start_key = list_of_keys.pop()
            #next_key = list_of_keys.pop()
            #print(start_key)
            #print(next_key) 
        #    while next_key != list_of_keys[len(list_of_keys)]:

               
        #        self.ShiftPools(start_key,next_key) 



        #    for key in self.DictionaryOfPools.keys(): 
        #        print("Pool Number: " + str(key)) 
        #        print("==================") 
        #        for player in self.DictionaryOfPools[key]: 
        #            print(player.Firstname + " " + str(player.UniqueSum))  
                   
                    
                    

        #def ShiftPools(self,current_key,next_key):
           
        #        if( len(self.DictionaryOfPools[next_key]) != 0):
        #            player_to_move = self.DictionaryOfPools[next_key].pop() 
        #            self.DictionaryOfPools[current_key].append(player_to_move) 
        #            self.DictionaryOfPoolsizes[current_key] += 1 
        #            self.DictionaryOfPoolsizes[next_key] -= 1
        #        else:
        #            self.DictionaryOfPools.pop(next_key)
        #            next_key+=1                                 
        #    return


            
                 


        def SortAllPools(self): 
            for key in self.DictionaryOfPools.keys(): 
                self.DictionaryOfPools[key].sort(key = lambda c: c.UniqueSum)
            return


                



            


        

        
        


            



class InputFileGenerator(object): 
        def __init__(self,filename):
            self.filename = filename
        def RandomToFile(self, number,club_num):
            open(self.filename,'w').close() 
            f = open(self.filename,'w')


            list_of_alpha = string.ascii_uppercase
            rand = random
            name_count = 1
            for x in range(0,number): 
                random_num = str(rand.randrange(0,club_num,1))
                random_index = rand.randrange(0,25,1)
                random_alpha = list_of_alpha[random_index] 
                random_rank = random_alpha + random_num 
                random_club = "CLUB" + str(random_num) 
                f.write("FIRST NAME" + str(name_count) + "," + "LASTNAME" + str(name_count) + "," + random_club + "," + random_rank) 
                f.write("\n") 
                name_count+=1 
            f.close()

            


def parse_file(file_path): 
   
    f = open(file_path,'r')

    newDict = {}

    listOfplayers = []

    for line in f.readlines():
        line = line.split(',')
        if(len(line) >= 3):
        
            alpha = line[3].strip()
            alpha = alpha[0]
            number = line[3].strip() 
            number = number[1:len(number)]
            new_player = Player(line[0].strip(),line[1].strip(),line[2].strip(),alpha,number)  
            listOfplayers.append(new_player)
    return listOfplayers 

 

        

        


if __name__ == '__main__':

    file_path = "C:/Users/Owner/Desktop/input_file.txt"
    generator = InputFileGenerator(file_path)
    input_number = input("How many random players?") 
    random_clubs = input("How many random clubs?") 

    generator.RandomToFile(int(input_number),int(random_clubs))
    player_list =  parse_file(file_path) 
    tournament = Tournament(player_list) 
    #tournament.OrganizeOnnumberRank() 
    tournament.BuildTournament()


	