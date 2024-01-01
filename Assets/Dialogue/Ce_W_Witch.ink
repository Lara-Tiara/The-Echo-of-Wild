INCLUDE globals.ink
Vespera: Great power comes with great resposibility.
->VesperaEncounter
=== VesperaEncounter ===
* [Approach Vespera] Cedric: Greetings, are you Vespera, the witch of the woods?
    Vespera: Indeed, I am the keeper of forgotten lore and ancient magic.
    -> VesperaDialogue

== VesperaDialogue ==
    * [Ask for help] Cedric: I seek knowledge about the Arcanum Chest. Can you assist me?
        Vespera: To discern the wise from the fool, a test of your insight I shall propose.
        **[Wisdom] Cedric: My mind is ready.
        {~->RiddleChallenge|->Fail}.
    * [Leave] ->Leave

== RiddleChallenge ==
    ** [Leave] ->Leave
    ** [Riddle] Cedric: I choose to face your riddle.
    Vespera: "The past, the present, the future, I hold,
    Vespera: "In sacred numbers, my tales are told.
    Vespera: "Within the Hallows, elements align,
    Vespera: "A cloak, a wand, a stone divine.
    Vespera: "my secret lies in the most stable form, 
    Vespera: "where points meet and bonds are born.
    Vespera: "In stories old and riddles grand,
    Vespera: "Name me, the number on which you stand."
    
    Cedric: The answer is a number from zero to nine.
        ***[Three] Cedric: Surely, it's three.
            Vespera: Wise indeed! The path is clearer to you. -> CorrectAnswer
        ***[One] Cedric: Could it be one?
            -> WrongAnswer
        ***[Nine] Cedric: Perhaps nine?
            -> WrongAnswer

=== Leave ===
Cedric: Thank you, Vespera. Farewell for now. -> END

=== CorrectAnswer ===
*[Leave] Cedric: Thank you for your guidance!->END
*[Gratitude and leave] Cedric: Your wisdom is unparalleled. I'm grateful.
    Vespera: Farewell, young seeker. Remember, three holds the second position.->END

=== WrongAnswer ===
Vespera: No, that is not the essence. Seek deeper understanding. -> END

=== Fail ===
Vespera: Not all are ready for the truth. Return when you are prepared. -> VesperaDialogue













