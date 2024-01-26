INCLUDE globals.ink
EXTERNAL loadScene(sceneName)
 
->confrontation
=== confrontation ===
    Oisin: Release the shepherd, for he has done no wrong.
    Bunny Lady: Ah, the mighty Oisin comes forward. Your cage was comfortable, wasn't it?
    -> ConfrontationDialogue

== ConfrontationDialogue ==
    * [Demand Release] Oisin: Cedric acted out of courage and compassion. Such kindness should be rewarded, not punished.
        Bunny Lady: kindness? In my kingdom, power is the only way. And you, Oisin, have lost yours.
        -> DemandRelease
    * [Plead for Mercy] Oisin: Show mercy, as befits a queen. Our hatred towards each other should not involve innocent people.
        Bunny Lady: Mercy is for the weak. But perhaps... there is a game to play here.
        -> PleadForMercy

== DemandRelease ==
    * [Show Strength] Oisin: I may not have my acient power, but my voice still commands many.
        Bunny Lady: Commands many, but controls none. Your roar is silent here, Oisin.
        -> EndConfrontation
    * [Offer Exchange] Oisin: What is it you desire? I will take the shepherd's place.
        Bunny Lady: Tempting, but what use have I for a toothless lion?
        -> EndConfrontation

== PleadForMercy ==
    * [Offer Wisdom] Oisin: We can work together, I would offer wisdom of ages past.
        Bunny Lady: Wisdom does not protect thrones. Power does.
        -> EndConfrontation
    * [Offer a Deal] Oisin: There must be something you desire. Name it, and spare the boy.
        Bunny Lady: What I desire... is your acknowledgment of my reign. Swear fealty, and he goes free.
        -> EndConfrontation

== EndConfrontation ==
* [Accept Terms] Oisin: If it will save Cedric, I accept your terms.
    -> AcceptTerms
* [Refuse] Oisin: Never will I bow to you.
    -> RefuseTerms

=== AcceptTerms ===
Bunny Lady: Wise choice, Oisin. I accept your submission.
-> ReleaseCedric

=== RefuseTerms ===
Bunny Lady: Then you leave me no choice. Guards!
-> PunishBoth

=== ReleaseCedric ===
* [Cedric is Released] Bunny Lady: Take your shepherd and leave my sight.
    Oisin: Come, Cedric. You are safe now.
    ~ loadScene("Ending3")
    -> END

=== PunishBoth ===
* [Both Punished] Bunny Lady: Take them both away!
    Oisin: Fear not, Cedric. This is not the end.
    ~ loadScene("Ending4")
    -> END
