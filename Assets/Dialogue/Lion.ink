INCLUDE globals.ink
EXTERNAL playSound(soundName)
EXTERNAL loadScene(sceneName)

Cedric: Please! I need help!
* [Ignore] Cedric: Sorry, I'm a little busy right now. -> END
* [Asking] Cedric: What happened to you?
    -> Divert1

== Divert1 ==
Oisin: I was entrapped here by the Bunny Lady's scheme. 
Oisin: Had you not opened the chest and discovered the true essence of the Echo of the Wild,
Oisin: I would have remained undiscovered forever.
* [Who did this to you] Cedric: Do you have any idea who might have set this trap?
    Oisin: I suspect the guards of the Bunny Lady. 
    Oisin: She's determined to prevent any challenge to her rule, 
    Oisin: even if it means trapping the guardians of the forest.
    ** [Go Back] -> Divert1
* [What do you want] Cedric: What can I do to help you?
    Oisin: Could you help me escape from this trap, please?
    ** [No] Cedric: I'm not sure it's safe to release a lion, even one as grand as yourself...
        -> Refuse_Ending
    ** [Yes (Risky)] Cedric: Of course, I'll help. You won't harm me, will you?
        Oisin: Never. I would never harm someone who is trying to save me. But I won't forget those who have tricked me.
        *** [How can I help you] Cedric: Let me see... This trap is tightly secured.
            Oisin: If you could use some magic to free me...
            **** [Use Magic] Cedric: I'll try using a spell.
                ~ playSound("Magic")
                -> Magic_Helping
                
            **** [Use Brute Force] Cedric: Let's try the old-fashioned way.
                ~ playSound("Force")
                -> Manual_Helping

=== Refuse_Ending ===
Cedric: You refused to help the lion.
~ loadScene("Ending1")
-> END

=== Magic_Helping ===
Cedric: You decide to use forbidden magic to rescue the lion.
* [Leave]
~ loadScene("CutscenePrison")
-> END

=== Manual_Helping ===
Cedric: You manage to free the lion using brute force.
* [Leave]
~ loadScene("CutscenePrison")
-> END
