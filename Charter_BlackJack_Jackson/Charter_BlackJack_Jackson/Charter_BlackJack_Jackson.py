import sys 
import os 
import random



# Ok so the entire program doesn't work I know you said to keep my solution time 
# down to an hour. I did get the player part working. The game function just needs a little more 
# code to implement a black jack dealer 



SUITS = ['Clubs', 'Spades', 'Hearts', 'Diamonds']
VALUE = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']



class A_Card(object):
    def __init__(self, suit, rank):
        self.suit = suit
        self.rank = rank

        if rank == 'A':
            self.point = 11
        elif rank in ['K', 'Q', 'J']:
            self.point = 10
        else:
            self.point = int(rank)

        self.hidden = False

    def __str__(self):
        if self.hidden:
            return '[X]'
        else:
            return '[' + self.suit + ' ' + self.rank + ']'

    def hide_A_Card(self):
        self.hidden = True

    def reveal_A_Card(self):
        self.hidden = False

    def is_ace(self):
        return self.rank == 'A'

class Hand(object):
    def __init__(self):
        self.hand = []

    def add_A_Card(self, A_Card):
        self.hand.append(A_Card)
        return self.hand

    def get_value(self):
        aces = 0
        value = 0
        for A_Card in self.hand:
            if A_Card.is_ace():
                aces += 1
            value += A_Card.point
        while (value > 21) and aces:
            value -= 10
            aces -= 1
        return value
class A_Card_Deck(object):
    def __init__(self):
        self.A_Cards = [A_Card(suit, rank) for suit in SUITS for rank in VALUE]
        self.shuffle()

    def __str__(self):
        A_Cards_in_A_Card_Deck = ''
        for A_Card in self.A_Cards:
            A_Cards_in_A_Card_Deck = A_Cards_in_A_Card_Deck + str(A_Card) + ' '
        return A_Cards_in_A_Card_Deck

    def shuffle(self):
        random.shuffle(self.A_Cards)

    def deal_A_Card(self):
        A_Card = self.A_Cards.pop(0)
        return A_Card
class Dealer(Hand):
    def __init__(self, name, A_Card_Deck):
        Hand.__init__(self)
        self.name = name
        self.A_Card_Deck = A_Card_Deck
        self.isBust = False

    def show_hand(self):
        for A_Card in self.hand:
            print( A_Card),
        print

    def hit(self):
        print("Hitting...")
        self.add_A_Card(self.A_Card_Deck.deal_A_Card())
        return self.hand

    

    def check_bust(self):
        if self.get_value() > 21:
            self.isBust = True
            print ("%s gets bust!") % self.name
        else:
            self.stand()


class Player(Dealer):
    def __init__(self, name, A_Card_Deck, bet):
        Dealer.__init__(self, name, A_Card_Deck)
        self.bet = bet
        self.isBust = False
        self.isSurrender = False
        self.isSplit = False
        self.split = []

def play():
	deck = A_Card_Deck(); 
	player = Player("Player1",deck,1)
	print( player.name + ':',
	player.show_hand())
	if player.name == 'Dealer':
	    while player.get_value() < 17:
	        player.hit()
	        player.show_hand()
	    player.check_bust()
	else:
		
		choice = input("Hit or Stand? (h or s)")
		while choice == 'h':
			player.hit()
			player.show_hand()
			if player.get_value() > 21:
			    player.isBust = True
			    print("%s gets bust!" % player.name)
			    break
			choice = input_func("Hit or Stand? (h/s) ", str.lower, range_=('h', 's'))
			
		if choice == 's':
			print("Stand")

	

if __name__ == '__main__':

	print("Let's Play BlackJack!")
	play()
       





