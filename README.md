# Arena
Simple console simulation of rpg arena fights.

How it works:
1. Choosing two fighters
2. In the upper right corner of the console we can see health points (*) and armor (#) of each player.
3. Each turn starts with Initiative phase. Each champion rolls for initiative. Number of dices is determined by stastistic. Player with highest sum of spots on his dices wins this phase and gains bonus dice in the Attack phase. If tie - noone gest bonus dice
4. Attack Phase: Each playes rolls for attack with dices determined in his statistics. Now we count only the number of 'succeses' - 5 or 6 on each dice. Winner of this phase deals as much damage to his opponent as his statistics show. If tie - we need to play this phase again.
5. Damage is taken first on armor, but when it is destroyed, player starts to loses his healt points. 
6. The initiative and attack phases are repeated untill one of the champions loses - lost all of his health points.  
