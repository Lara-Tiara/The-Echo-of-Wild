INCLUDE globals.ink
EXTERNAL loadScene(sceneName)
 
->confrontation
=== confrontation ===
    Aslan: Release the shepherd, for he has done no wrong that warrants such wrath.
    Bunny Lady: Ah, the mighty Aslan comes forth. Your cage was comfortable, wasn't it?
    -> ConfrontationDialogue

== ConfrontationDialogue ==
    * [Demand Release] Aslan: Cedric acted out of courage and compassion. Such virtues should be rewarded, not punished.
        Bunny Lady: Virtues? In my kingdom, power is the only virtue. And you, Aslan, have lost yours.
        -> DemandRelease
    * [Plead for Mercy] Aslan: He is but a child of the land, acting upon the laws of old. Show mercy, as befits a queen.
        Bunny Lady: Mercy is for the weak. But perhaps... there is a game to play here.
        -> PleadForMercy

== DemandRelease ==
    * [Show Strength] Aslan: I may not have my former power, but my voice still commands many.
        Bunny Lady: Commands many, but controls none. Your roar is silent here, Aslan.
        -> EndConfrontation
    * [Offer Exchange] Aslan: What is it you desire? I will take the shepherd's place.
        Bunny Lady: Tempting, but what use have I for a toothless lion?
        -> EndConfrontation

== PleadForMercy ==
    * [Offer Wisdom] Aslan: I can offer you counsel, wisdom of ages past.
        Bunny Lady: Wisdom does not protect thrones. Power does.
        -> EndConfrontation
    * [Offer a Deal] Aslan: There must be something you desire. Name it, and spare the boy.
        Bunny Lady: What I desire... is your acknowledgment of my reign. Swear fealty, and he goes free.
        -> EndConfrontation

== EndConfrontation ==
* [Accept Terms] Aslan: If it will save Cedric, I accept your terms.
    -> AcceptTerms
* [Refuse] Aslan: Never will I bow to tyranny.
    -> RefuseTerms

=== AcceptTerms ===
Bunny Lady: Wise choice, Aslan. I accept your submission.
-> ReleaseCedric

=== RefuseTerms ===
Bunny Lady: Then you leave me no choice. Guards!
-> PunishBoth

=== ReleaseCedric ===
* [Cedric is Released] Bunny Lady: Take your shepherd and leave my sight.
    Aslan: Come, Cedric. You are safe now.
    ~ loadScene("Ending3")
    -> END

=== PunishBoth ===
* [Both Punished] Bunny Lady: Take them both away!
    Aslan: Fear not, Cedric. This is not the end.
    ~ loadScene("Ending4")
    -> END
