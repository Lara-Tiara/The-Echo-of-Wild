INCLUDE globals.ink
Saoirse: Great power comes with great responsibility.
-> SaoirseEncounter
=== SaoirseEncounter ===
* [Approach Saoirse] Cedric: Greetings, are you Saoirse, the witch of the woods?
    Saoirse: Indeed, I am the keeper of forgotten lore and ancient magic.
    -> SaoirseDialogue

== SaoirseDialogue ==
    * [Ask for help] Cedric: I seek secrets about the Arcanum Chest. Can you assist me?
        Saoirse: Indeed I know the number. But not everyone is the right person to share the secret.
            ** [Use magic SECRETLY] Oh is that true?
            {~->Success|->Fail}
            ** [Ask sincerely] How to prove that I am the right person?-> ConverseWithSaoirse

== ConverseWithSaoirse ==
    Saoirse: To discern the wise from the fool, a test of your insight I shall propose. Let us converse.
    Saoirse: Tell me, Shepherd, what is the shape that holds the world together?
    *   "The circle." 
        Saoirse: Indeed, but incomplete. The circle has no beginning and no end, yet something else underlies the foundation of all. 
        -> ContinueConversation
    *   "The triangle." 
        Saoirse: Precisely. A shape of stability, where points meet and bonds are born. 
        -> CorrectPath
    *   "The square."
        Saoirse: The strongest shape, yet not the one that underpins the essence of all. 
        -> ContinueConversation

== ContinueConversation ==
    Saoirse: Consider the elements of the world. How many do you deem fundamental?
    *   "Four elements."
        Saoirse: Indeed, yet there is a trinity that is often overlooked in the balance of nature.
        -> CorrectPath
    *   "Five elements."
        Saoirse: Five brings complexity, but simplicity often holds the key to understanding.
        -> CorrectPath
    *   "Three elements."
        Saoirse: Ah, now you see the core of all - a trio that stands at the heart of existence.
        -> CorrectPath

== CorrectPath ==
    Saoirse: Your answers reveal an understanding. Now, think of numbers, of tales and legends. Which number stands as the foundation?
    *   "Three."
        Saoirse: Wise indeed! You understand the essence. The number three is key to the Arcanum Chest.
        -> CorrectAnswer
    *   "One."
        Saoirse: One is the beginning, but not the foundation of all. Reflect again on the essence of things. 
        -> WrongAnswer
    *   "Nine."
        Saoirse: Nine signifies completion, yet it does not underpin the core. Look to simpler origins. 
        -> WrongAnswer

=== CorrectAnswer ===
    *[Leave] Cedric: Thank you for your guidance!->END
    *[Gratitude and leave] Cedric: Your wisdom is unparalleled. I'm grateful.
    Saoirse: Farewell, Cedric. Remember, three holds the second position.->END
        
=== WrongAnswer ===
Saoirse: No, that is not the essence. Seek deeper understanding. -> END

=== Success ===
Saoirse: The number three is key to the Arcanum Chest.
Saoirse: What did you do? You sly young man!->END

=== Fail ====
Saoirse: Perhaps your power is not as strong as you think.
*[Leave] I would be powerful one day.->END
*[Try your Wisdom] I think I can still get the number without using of magic.-> ConverseWithSaoirse













