INCLUDE globals.ink
EXTERNAL loadScene(sceneName)
 
Are you going to save Cedric from The Bunny Lady?
* [Yes, I cannot fail such a kind soul.] Besides, we need him on our journey towards freedom.
    **[Leave]
    ~ loadScene("Scene2_City")
* [No, It's too risky to attempt a rescue now.] We need more time to prepare and recover.
    **[Leave]
    ~ loadScene("Ending2")
