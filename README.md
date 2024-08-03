# Shaman Design Document

Name TBC

Battle Chess meets leveless fusing Pokemon with non-linear story and world and a unique Spirit-punk Aesthetic
Play as a Shaman = a bard necromancer spirit ranger priest

## Pitch
Pixel RPG, capturing that gba feel (implying pixel art with 16-bit colours, will be ripping pokemon sprites as dev art as I slowly learn to pixel art / buy art myself)
Using shamanism capture various spirits that can be combined to grow and cultivate their powers, to fight off aggressive spirits, other shamans and the wild world of Zylen (name TBC).

Spirits roam the wild making it dangerous to leave the village, but Shamans are humanity’s solution. They learn the ways of the myriad spirits and capture them into Instruments, psychically charged items of weight, to store and carry spirits with them to study, train and fight alongside with, and protect what remains of humanity. 

The world is post-collapse of modern society with spirits echoing the harms and heights of that ancient past (and a fable on present day ills, where our mistakes will literally haunt us), in a world more dangerous but more focused on the correct action of the individual for the good of small collective communities. Ancient ruins and ancient techs surface on occasion on this shaman-punk spirit coexisting world littered with rediscovered technologies (like spirit powered trains) that function alongside spirit aided contraptions (such as electric trams powered by electrical spirits). 

Basically a thought experiment on what my pokemon esque game would be like, with most systems designed on better realizing their potential than pokemon’s;
No IVs EVs or levelling, replaced by a Meta level and stat training system. 
More dynamic entities - day/night, moving trainers, dynamic rivals, unique / specialised capture mechanics etc
More emphasis on training a themed team through team and meld bonuses, and the battlegrid system meaning one spirit cannot be everywhere at once. 
More characterisation & actual roleplaying. 

Being made in raylib c#.

## Shaman MVP Todo
A demonstration software of Shaman’s core loop; capturing spirits for use in fights to protect what remains of civilization.

Main Menu – game load / new game

World Map scene transition – image masking?

World Level Demo
•	Map designer pipeline
•	Map load system

Dynamic Character Trait demo – pickup various items, main menu character card to show what their current tags are

NPC & Conversation tree demo

Basic Spirit List, one of each type: Shambling Undead (pc), Spirit of Storms (pn), Broken Disc (am), Forgotten Predator (eb), Ash Fiend (ag), Sloth (hp)

Battle Scene Transition

Basic battlegrid and autobattle system demo

Wild Battle demo

Spirit Capture Systems Demo

Duel Battle System Demo

Spirit Manager & Menu Demo

Character Customisation Scene
- Clothes System

Save / Load System (real time game state serialisation vs saved states, an 'ironman' mode)

## Capture System
Pokemon’s system is simple, tedious and boring. While there’s some exploration of the possibilities of different ball types, it’s not done well.

To be captured, spirits must first be Bound by ritual and then defeated. 

Spirits are bound to “Instruments”, initially a set of bronze bells, kept on the Shaman’s person. Spirits must be bound to the right kind of Instrument and this can depend on region, spirit type, phenological identifications etc. 

Binding works based on circumstance, which produces a likelihood level (visible to the shaman, or visible after learning a certain ability / earning a certain key item TBC). Circumstances are known as the “ritual”. Levels: certain, likely, unlikely, near zero, none. A ritual effects all wild spirits on the field with each having individual binding levels (if they’re different kinds of spirits), which each being bound to a different Instrument upon success (if possible).

Binding fail chance only exists for non-ideal circumstances, replacing the tedium of output chance with little tactical meaning, with the demands of setting up a correct ritual and succeeding in battle. As such upfront capture chance (if with fuzzy levels not %).

Defeating a spirit in battle that has been bound is then captured (dependent on success chance and appropriate instrument availability) and prevents the annoying situation where feinting a pokemon prevented you from capturing it. 

Player agency really comes in during the process of binding and the ritual than can be behind that. It depends on a host of dynamic reasons on a per-spirit basis, from regional effects (Lava imps can only be bound when the local volcano is not erupting) to the presence / absence of elements (night shades can only be bound during cloudy nights when the moon is obscured) to the use of specially prepared items (shambling cadavers are bound with grave shrouds) etc. 

A more complex example: the unicorn White Knight requires a passive (weaponless) female (presenting) shaman to be bindable, and is bound to a hand harp Instrument. 

Most Rituals conditions should occur or have steps outside of battle actions, to emphasis and broaden non-combat gameplay, and tie them together.

Game generates ritual tag list for current circumstance that spirit class references to return bind chance.

## Time
Season, sun position, moon position & phase all could matter to capturing so a quick simple way for the player to see this is needed, such as “view sky” system.

## Type System
As per autobattlers Shaman’s types have synergy and anti-synergy bonuses/maluses that come into play through team composition and enemy matchup, but generally also function as design themes for the spirits. Not just artistically but mechanically, for damage profiles, moves, spawn locations, behaviours, events interaction etc. As such all spirits are dual-type or even triple / quadruple type, and the types below are a bit different to the old-school rpg types, or pure 'elemental' types a lá pokemon.

Types fit into one of 3 (TBC) categories: Kind, Role, Facet

Damage types come from moves only.

### Spirit Kind types: 
- **Auld machines**; the unnatural extravagances of the ancients, broken and corrupted remnants of more decedent times that harass the present. 
- **Extinct beings**; the powerful echoes of old life, primal ferocity rearing its head again, taking on form to physically remind the living of their legacy. 
- **Polluted natures**; aspects of nature poisoned and abused, their rebellion giving birth to foul spirits. 
- **Haunting psyches**; the daemons of humanity’s haunted psyche returning in semi corporeal form, clawing at the innocent with the sins of the passed. 
- **Possessed cadavers**; the corpses of the passed which rise again under malign force. 
- **Ancestral ghosts**; the spirits of the dead, unable to leave the earthly sphere, haunting those to whom they are bonded. 

### Spirit Role types:
- **Berserker** - all out melee offensive
- **Slugger** - a.k.a. bruiser, mixed offensive defensive mostly melee
- **Sniper** - long range attacker
- **Trickster** - malus utility
- 

### Spirit Facet types
A group-categories physical or meta-physical trait of the spirit
- **Winged**
- **Ghosts**

## Spirit List
Spirits so far.

151 base spirits (homage)
1.	Restless Ghost - ag ghost of a discontent ancestor
2.	Shambling Undead - pc a spirit animating an unburied corpse
3.	Ash Fiend – ag the ashes of the dead laced with an unsatisfied spirit
4.	Carrier Flock – eb flock of pigeons carrying mail
5.	Smog – pn poisonous cloud that seeks to suffocate
6.	Downpay – hp the draining effect of making the future pay, in the form of a vampiric credit card
7.	The natal spirit - a.g. The shadow of the unborn
8.	Broken Disc - a.m. Lost music must be heard
9.	Corrupted Hardware – a.m. Rampant computing
10.	Unnetworked Node – a.m. That wants to reestablish the internet of things & people
11.	Displaced Sentry – a.m. A combat bot
12.	Buzzing Drone – a.m. An annoying in-your-face drone
13.	Cyberhusk – a.g. / a.m. Fusion of unnetworked node and forgotten traveller
14.	Forgotten Traveller - p.c. It knows not where it travels, only that its journey never ends. 
15.	Junkyard Dog am – a conglomerate of abandoned and forgotten vehicle parts, it wants to carry people long distances, but is no longer safe or able. 
16.	Forgotten Predator be – a raptor
17.	Poached Lion eb
18.	Harvested Whale eb
19.	Spirit of Droughts
20.	Spirit of Storms pn 
21.	Spirit of Sea Surge pn
22.	Spirit of Wildfire pn
23.	Spirit of Quakes pn
24.	Spirit of Melted Glaciers pn
25.	Cracked Micro Reactor am
26.	Plagiariser hp - copies the form of a nearby spirit but keeps its type.
27.	Unicorn Knight hp – unicorn white knight that seeks to maintain the possessive nature of purity of females
28.	Workmeat – pn the mutated fused form of overworked and overfarmed animals
29.	Corruptive Desire hp – Lust spirit
30.	Insatiable Thirst hp – Greed spirit
31.	Envy hp
32.	Sloth hp
33.	Wrath hp
34.	Gluttony hp
35.	Pride hp
36.	Moa eb
37.	Giant Eagle eb
38.	Prehistoric Violence – hp a maori spear thrower
39.	Antiquated Violence – hp a maori musket
40.	Violence of the Collapse – hp an automatic gun & grenade belt
41.	Slaughterbird – pc poorly slaughtered Foulbird corpse
42.	Chokebird – pn the birds of the trashheaps
43.	Fortuna – hp the little pieces of luck humans often beg for
44.	Disappointed Ancestor – a.g. why you no be doctor
45.	Spirit of Abandoned Puppies – a.g. Vengeful starving baby pets! wow

## The Shaman's Codex
The pokedex, but written first person by the PC upon encounter (as indirect characterisation and story telling) and through notes from other shamans collected in varies ways. As opposed to a weird encyclopedia that only tells you about something once you have it. 

Three part entries; personal notes on encounter, calming and other notes (written by other shamans), technical notes (on capture, inc stats and misc stats, by the player (1st person)).

## Characterisation
It isn’t just visual customisation, but roleplaying options and things which effect later encounters and options, from Calming to conversation options.

However, no character creation; every appearance option (inc. gender) is decided during play. The Shaman is introduced as a nameless individual stricken of identity by the ritual of becoming a shaman, head shaven and neutrally clothed.

Aspects of characterisation are all seen through the lens of gameplay impact. Personality / lifestyle options (effects interactions through tag system), background (use other game and world features to backfill these options, gives access to unique events, items, interactions)

Choose personality traits for yourself, better yet have your actions dictate your personality, have a therapist guru npc be the point of contact for editing it. No menus!

Clothes / Presentation System - (particularly colour variants) inc. gender presentation (male / female / both / none) and other presentation factors (faction identification, wealth indication, shamanist degree indication). 

Non bagged items are "worn" and may entail presentation factors. 

Use the various presentations for certain spirits and encounters. 

Items need to be "worn" to be used in combat or other high stakes encounters, otherwise its an action to equip / unequip / swap.

### Weapons & Armour
Two particular kinds of worn items matter to combat: weapons and armour. Your weapon determines your autobattle Move. Your armour aids your defence as well as Vulnerabilities and Resistances.

## Herbalism, Potion,  Healing & Maintenance
No pokecentres and pokecentre spam, only potions, traditional medicine (herbology lol I forget the word for plant knowledge medicine) and nightly rests.

Potion recipes are a liquid base mixed with up to a number, 3 (tbc), soluble substances. Potions include; 
- One or a class of these are healing potions. 
- Stat buff potions
- Debuff removal tinctures
- Type Masking Perfumes – make a spirit count as another type
- Offensive bombs (weapons) – for damage, maluses and conditions

Nightly Rests remove temporary maluses and restore a fraction of total health / coherence. It allows self healing to occur. Resting can be done at campfires or beds (such as the inn, or in friendly NPC houses) and advanced time to the next morning.

### Maintenance
Replacement parts. Some Spirits have body parts that don’t self heal if broken. They must be replaced, such as Broken Disc’s Disc part. This is Maintenance. Such items can be found and bought. 

## Dialogue System
Instead of dead chat reels. In here personality (and other triggers, such as presentation) unlocks new dialogue. Umming and ahing over dialogue trees with options, dialogue pools, or what have you. 

More importantly, the main character should speak back! Their own pool of responses determined by personality traits. 

Backfill from other features for ideas and options. 

## Damage
To switch things up a bit from the usual. More top-level approach than fundamental forces level approach.

### Damage Types: 
- Physical Attacks – Strike, Shot, Sickness, Chemical
- Energy Attacks – Heat, Cold, Water, Shock, Radiation
- Supernatural Attacks – Force, Chi, Psychic

Damage Resistance (1/2) and Vulnerability (x2) decoupled from type on a per Spirit basis informed by type and design. By default a spirit should have a resistance and vulnerability. 

## Spirit Condition
New not-HP system using body parts and status chains / trees. Each body part corresponds to a hit chance and its damage / loss has effects. Nevertheless this needs to be visibly satisfying and readable. 

Might just throw in with the HP crowd, or do a two-level system. Fighting spirit ju-ju as HP, host body damage incurs maluses and conditions. 

Other status effects.
•	Mad – will make its own random offensive moves
•	Tackled – pinned, no movement or retaliation
•	Afraid – will not approach, attacks are at a disadvantage
•	Charmed – must approach charmer, will not attack
•	Hobbled – movement (recovery) halved
•	Blinded – senses impaired, reach set to 1
•	Disarmed – weapon loss, attack decreased, armed moves (weapon using) prevented
•	Empowered – act at an advantage (% to fail halved)
•	Weakened – act at a disadvantage due to poison, radiation etc
•	DoT (Bleeding, Burning, Freezing, Drowning, Poisoned, Irradiated) – dealing wounds to certain body regions at a stated rate. 
•	Stunned – temporary suspended speed
•	Down – but not out
•	Dead – and in need of burial

## Auto Battle Systems
Intentions: engaging fun, slick quick and hands off but deep. Strategic but not bogged down or overburdened with difficult to read details.

A complete departure from pokemon, using a battle grid, many spirits at once (although with triple battles etc they were heading here), and terrain. Also there’s no damage HP system. (TBC?)

Themed team composition gives bonuses. More themes than just creature types!

Order of Battle: each spirit has a Speed stat and an Initiative Stat that is derived from speed (but also other areas), so spirits with higher initiative go first and higher speed act more often (a spirit with speed 20 takes twice as many actions as a spirit with speed 10).

Defeat - What happens when a spirit runs out of health (so there is health) depends on the spirit; death, banishment, immobilisation, cannot die (only calmed/forced to flee) etc.

### Spirit states:
Enraged: (Monster hunter has the right of it)
Aggressive: normal
Fleeing: attempts to leave the board and run away. Some spirits don’t Flee, such as all Possessed Cadavers, and will fight to the “death”.

## Battlegrid
Each "side" is a 8x4*, or 9*3 with 3 row nomans land, grid that together make a square on a 45 degree angle making use of 2.5D.

There could be a different sized grid, with the Battlegrid itself being dynamically generated according to terrain (for wild fights) and/or agreed upon duel rules (for Shaman fights). Consider screen size. Shaman grid presence is also a variable. 

Attacks have a target (and travel method such as pierce (go through) and arc (jump to the target). 

Profile System - Movement, Cover & Size all effect hit chance. (We XCOM now?)

Team size depends on Shaman skill, key items, & battle rules (if duel).

Team composition has battle chess like combinations and anti-combinations to encourage thematic teams. 

## Moves
Large departure from Pokemon moves system. Less moves and no forgetting of moves or HM's (though moves that effect the world big yes). TM’s are new trained behaviours.

Wild and basic spirits follow basic autobattle rules: move into range if not, attack with your basic attack, when special meter fills do special attack.
Basic Behaviour:
-	Special Attack (if special meter is at 100)
-	Basic Attack (if enemy in range)
-	Reposition

As such a spirit’s attack and special attack are their “moves” in pokemon parlance.

Any further Moves, then, are trained “behaviours” where within the above logic the shaman can insert new behaviours and moves. Such as “protect” where move into range becomes move to tile in front of shaman.

As for the actual moves, lift/heavily-inspire names from pokemon (tackle, smokescreen, screech etc) but have much more sensible effects. As a heavier nod but also more obvious ‘this is how things should have been done’. Moves to be sorted into attack-defence-utility paradigm to blend with meld mechanic, or to be associated with the subsections of the spirit. 

Moves can “evolve” along a mini-tree or straight up upgrade. Variety comes from choice. Moves are shared between spirits but certain unique moves or evolutions dependent on spirit.

Spirit melding into weapon armour or utility transfers those moves / a move of the same kind.

Order of Moves, i.e. “Behaviour”, sets their precedence when determining what to do.

Spirits reposition to a target based on their next Move: as in-range depends on the Move’s range, but is otherwise direct and simple with predictable shortest-path pathfinding. (Crack out that A* algorithm).

## Move List
tackle, smokescreen, growl, tail whip, thunderstrike, psybeam, vinewhip, razorleaf, watergun etc

## Terrain Objects & Effects
Coverage

Tile Blockers / Difficult (slows) / Dangerous Terrain (slows and damages)
Ledges (between certain tiles, can be scaled by those with a climb speed or flown over)

Terrain affecting / creating moves

## Duels & Battles (fight initiation)
Wild Fights – when in the wild there is a run in chance which refers to an encounter table, as well as specialised encounter methods (such as flicking a silver coin into a fountain to summon a Fortuna). 
Wild fights have the summoner on field and only companion spirits start “out” with shamans having to summon other spirits into the field. 

Battles – shaman fights (e.g. trainer battles) are more nuanced. Any shaman character can be propositioned to duel, many especially in town (in contrast) will proposition you, and only bad guys / hostile situations will a fight be forced (often with wild fight rules). Battle types inc; 1v1 duels (with various restrictions / classes), X soulweight vs X, full fights (i.e. like wild minus shaman on field). 

Dynamic Enemies – enemies that join during other fights, scripted or dynamicallly based on environmental factors. 

Losing depends on the situation. Wild fight losses to Spirits depending on the spirit can; kill you (game over), maim you (wake later in maimed condition), or cause you to flee (exiting the region).

## Spirit Melding
The game idea origin mechanic; fusing aspects of spirits together a la pokemon fusions, but for gameplay variety not just lulz. 

Due to this core it might be a lot smarter to have a shorter list of base types (with various versions of each ofc) which are used for fusion logic, like; zombie, gaseous spirit, beast, bird, snake, tech etc. 

Fusion works by having all spirits belong to two phenotypes, a base and a layer type. When fusing one spirit is chosen as the Core (using base) and the other as the Infusion (layer). Some combinations are invalid. Sprite designs follow this paradigm. 
Base Types; whole (only takes highlight layer types), torso (the “core” body, takes all limb types), lower (for top – bottom split spirits, takes head, arms, upper) 
Layer Types; highlights (can be used on any, giving unique features and colour), head (self explanatory), appendages (for when distinguishing arms / legs is no good), arms, legs, upper (for top – bottom split spirits).

And unique fusion spirits; unique spirits gained only through melding two (or more?) specific spirits instead of dynamically making one. This is a yugiho ref. And also just cool.

Spirit colour schemes can and should also be combined and sprites dynamically recoloured.

## Spirit Forging
Transforming spirits into armour, weapons or utility items, to be used by the player or other tool-capable spirits, carrying over the stats and a move / moves of the spirit. 

To prevent yet another geometric expansion of work when it comes to spirits (sprites & programming), only certain items will be spirit forged, and not necessarily only from one spirit each. Many spirits won’t forge into anything. Sometimes a spirit could forge into one of many potential things, depending on circumstances (what Moves they know, for example).

## Animals
Are pokemon animals? Or are there normal animals too? For spirits the obvious answer is yes, there are (some) normal animals left, including;
•	the mutated insect the Rustevore (a rust eating oversized cockroach-moth analogue)
•	the Wildhound (ancestors of mongrel dogs), 
•	the common Horse – ride me
•	The foulbird – a feral dyno-fied chicken, refs the dino chicken project and the way humanity is twisting nature according to its whims
•	Bandits – humans are animals too, so human enemies should be just as encounterable
•	Thornlasher – danger foliage! Nature strikes back!

Though they fight just like normal spirits (i.e. they use the same battle system) they cannot be captured, are more likely to flee etc.

This is also true for the player.

There could be an alternate recruitment channel, such as hiring/earning allies, buying pets etc. bringing Animals onto your team.

## Meta Level System
Since explicit levels aren’t a thing in my game ideas, the replacement is the meta level system. Basically, instead of levels deciding stats, stats decide “levels”. But, as I’ve matured, I’m happy to continue using the word level, although “soul-level” is a better term I’d say. Or I really might go for “power-level”.

Meta Level is dictated by stat total, with exact stat-to-level scaling tbc. 

## Statistics
Frontend Statistics - Player visible within the UI
- Attack – physical attack power
- Defence – the base rate that each body region takes damage (higher defence, more enemy attack is scaled down). Actual HP determined by body regions
- Power* – energy attack power
- Resistance* – energy resistance
- Cognition* – supernatural attack power
- Will* - supernatural resistance
- Speed – how soon until its next turn
- Armour – the physical buffer of worn armour, functions like bonus HP
- Movement – ground / swim / climb / fly & distance (typically 1 tile, fast can do 2, ridiculously fast can do 3. Maybe only a handful of spirits in the entire game)
- Phenotype - Base & Layer codes, slightly obscured from system described here

*needed? will start without

Backend Statistics (to be honest totally unknown until implementation) - Actually employed by game logic and other hidden variables
- Stat Level Base Rate – the base rate for stat level progression, larger means more exp needed per stat level up, calculated in a formula that takes into account current stat level and SLBR
- Per Stat Experience tracker – free amount of experience in a stat used by the levelling system. 
- Hit Chance – the chance to be hit, normally 100% but moves and status effects may modify it.

## Statistic Training System
Replacing a levelling system there’s a stat regime training system, to better reflect what’s really going on. 

Spirits follow training regimes that dictate primary, secondary and tertiary stats that grow at a corresponding rate. Shamans learn regimes which they can coach their spirits in, finally learning to construct custom regimes with custom training. This system could include negative training in order to rebalance stats. 

Shaman’s dictate which regime to train per spirit (maybe a training system that takes into account moves as well as involved spirit) outside of combat, and their experience gain in battle goes to growing those stats. When a threshold of experience is reached, that stat goes up 1.  

Spirits have max stats for each stat, and a max stat total making a Spirit be in “Peak Condition”, meaning no further stats can be gained. These values depend on the spirit, meaning many spirits are essentially stronger than others, but none vastly outclass others merely due to “level” disparity.

## Settlement System
In case there wasn’t enough bloat in this game. I like settlement builders and production chains, so why not build a simple one here.

Recruit population. Condone or Bless marriages (for children) and Namings (‘christenings’) (for number of children).

Set up supply chains from raw resource to finish product/s. 

Why have this system at all? Because REASON 1/2/3…

## Story
Breaking from the hackneyed formula, there isn’t a professor, rival or gym system.

### Story: 
A village can only have 150 people. You’re the 151st (yes, a ref kinda) and on your 15th spring equinox, where the village counts years, you and the three other children of your year are gathered together both to celebrate the end of childhood, but receive your adulthood charges. You, with your criminal father and tragically passed-away-during-childbirth mother, has been “randomly” chosen to be the one afforded the impossible task: Become A Shaman, which doubles in having you kicked out of the village and cut off from the village’s supplies. You’re ritually de-named, head shaved, dressed in the grey robe, and ceremoniously kicked out.

Intro Story (totally ignorable): you’re told to go to the old shaman on the hill to receive training, the last person who received this charge, and get their blessing. They provide you with tutorial trials to complete within the proximity of the village, including first by securing some moonshine for them. They teach the basics of shamanism, how to fight and how to bind a spirit, bequeathing you a small bronze bell. They tell you if you wish to come home, you need to become a better shaman, to gain more instruments and prove your ability to use spirits. They will accede their position and you can become a village member again. If you want to.

Banished from your home, earning your way back is your first obvious goal.

After that the 'story' is purposefully open, in line with the non-linear map (not quite open world as its tile based but...). The 'Main Story' follows one the assistance / opposition of the player to Balance / Progress, with various TBC end states achievable. (This is a good point. Can't have a new game + without having a clear end state on which to roll credits and reset time.)

Instead the story, and exploration of regions, unfolds through a quests structure. No hard-coded "You have accepted this quest, here is a list of tasks to fullfill", just dialogue that implies courses of action and in game events that unfold according to wether and how much a player has met certain requirements. Each quest, if resolved 'successfully' (the meaning of which depends on the quest) will reward the player with an ingame ability, a key item or some other unlockable. Side Quests are those generally of smaller scale not related to the main factions. Faction, or main, quests are those that do.

### Quests (Faction)
- Save the Farmstead from what haunts it - a young priest of Balance assists you, and is pleased if you capture / calm the culprit rather than kill it
- Capture XYZ Spirit(s) for Research (Assists Progress), a chain of fairly simple bounty hunter quests
- Facility Breakout - release spirits held in Progress (often hidden) research facilities (Assists Balance).
- Burn down Monestary X - and take its wealth for progress (Oppose Balance, Assist Progress if turned in)
- The City of Ashes - what happens when the world is struck by a Tenbatsu. Should give player sympathy for Balance faction (as well as their initial nature good, be kind to spirits type coding)
- The Tenbatsu of Paradise Cliffs - after a period of interaction and indications of tension, will suffer a Tenbatsu and will also serve as the player's introduction to this natural disaster. Depending on player's alignment, they can help enforce / break the cordon, help the people flee, help fight back. The secret at the heart is the planting of a Locust Egg, a terrible but "necessary" evil conspiracy at the highest levels of Balance.
- A Settlement on the Brink - Tarleymore is full. They are at an adult population of 153, already technically 'over', and a whole generation of 21 children are going to reach majority over the next few years. Half the village has rebelled against the elders and the rule of the temple, with secretive Progress help, and now Balance are considering Extermination. Progress want you to smuggle the children, often against villager wishes, to their city for "safety". New Moon Tea 
and enough voluntary expulsion is a diplomatic solution.

### Side Quests
- Losing a Parent - help a girl find her lost mother, and when the corpse is lain to rest to give her a proper concecrated burial. Rewards burial rites key ability needed to capture possessed cadavers
- Fight off a Shobatsu - rewards Mana Dowsing Rods which allows player to find other shobatsu-to-be and profit off them
- Gather ingredients for and learn the recipe of Granny Applebee's New Moon Tea - allows for pop control
- 

### Factions:
Two shadowy organisations vie for power: the Ordinance of the Kamui “Balance” and the Union of the People for Peace and “Progress”.

Balance vows to keep humanity alive by preventing the chaos caused by population growth, which causes spirits also to explode in number in events known as “Tenbatsu”, but also power and aggression. Their dark side is that they forcefully exterminate population centres when they deem it necessary, and bloodily weigh in on population quota disagreements between settlements. Organised through the various temples spread across the villages and the independent monasteries.

Progress, who initially come across as the bad guys for experimenting on spirits and causing spirit surges “Shobatsu”, environmental damage etc. but run the only true city where personal freedoms are at their greatest, not least the right to have, and keep, children, in Crater City, and actually want humanity to thrive.

In truth both are quite grey organisations that the player can choose to join.

A “third” organisation, if you will, is a place called “Refuge”. This is the player’s settlement, if they choose to make one. A pseudo-settlement builder. Importantly, this can lead to conflict or cooperation with either of the two organisations. Can become a third organisation dedicated to finding a third way between Balance and Progress. (which is???)

Emphasis on the cultural prerogative of Shamans to serve humanity in this spirit laced world and protect the balance. Meet characters and factions that espouse different takes, rejections or outright ideologies along the way.

Accumulate all Shaman accolades (in game achievements) and become the Ubershaman of the land. 

Maximise the Civility/Wilderness/Spiritual Index of each region. Encourage the growth of humanity/nature/spirits.

## Region
Todo – switching this to an Albion-Yamato hybrid because A) write what you know and I know jack about NZ, and B) the fantasy of England and Japan is sells

Lifting from pokemon, use a real region as a template; a superimposed map of the British isles and the Japanese isles. If I allow myself to be ambitious, have it be the scale that the pokemon games imply (i.e. about 10 times the size of a typical pokemon map).

Area Ideas: 
ruined capital, interior desert, caldera, ash&lava fields & lava tubes, sea straight, fjords, cold forest, hot forest, windy plains, farming valleys, dry prairie. 

Just using biomes seems dry, like the same mistake of using old pokemon types. Each region should be like a spirit type, a strong thematic indicator that speaks of the setting.

Hillside, ‘Starter Zone’ – rolling hills of balanced humanity, nature and spirit. Used to introduce all core mechanics and get the player started. It shows the ideal of the game. 
Inc in Minimum Viable Product. 
Survivor Villages – when shit hits the fan, we run to the hills. Survivor hill folk whose pastoral ways saw them through the collapse. The home village of the Starter zone is one.
Monasteries – the priests of the Ordinance, when not running temples in the villages, have their own small settlements here – a mix of catholic and buddhist monasticism. 

Dried Out Badlands Zone – desert and scrubland, the intermediate zone that connects to the other zones. Crossroad of sins, threats from all of humanity’s many mistakes gathered together.

Farmsteads - Hardy entrepreneurs create terraced irrigated farms around the river. English / Japanese settler fusion. City folk don’t bother, due to the starving dead, the remnants of the great escapes into the country. Inside Badlands Zone. Balance presence.

Drowned Coast – free standing remains of ancient settlements peak above the waves. Shamans using spirit powers delve the depths whilst refugees from distant shores make in roads from their shanty towns. Inside Badlands Zone. Union presence. 

The Highlands and Peaks Zone – the old wilds closed ranks as ice and snow closed in. Only hardened Hunter gatherers and longboat nomads call it home, alongside iceage & eb’s. 
Mountain Pass & Glacier – gateway to Fiordlands Zone. 

Primal Jungle Islands Zone – far to the south, dinosaurs & riders, little factional presence but feral residents. The resilience of nature after cleansing fire. 
Lava fields & Choppy Seas – fire & water. The revenge of earth, hellscape. Gateway to Primal zone. 

The Straights Sea Zone – separating wilder south island from haunted north island.

Paradise Cliffs – sandy palm filled coral breaks and fishing villages. In chaotic uncertainty, we party like the old ones. Emulation of opulence and decadence. Inside sea zone, gateway to Ruined City Zone. 

Ruined City Zone – the echoes of ancients, home to the Wardens (a Balance sub group), guardians against ancient threats, fighting constant skirmishes against Unionist fighters that operate out of the tunnels.

Giant Nuclear Crater – some say the ancient city got lucky, that there is any of it left. Inside City zone. Filled to the brim with radiation spirits. A general no-go-zone.

Bunker City – the maze of semi occupied underground passageways. Inside city zone. 

## Shaman Accolades System, New Game+
A masked achievement system. Can have in game rewards and encounter effects. 

Full list of Milestones and their requirements listed after beating the game at least once.

This leads to new game+, keeping your old kit and spirits you venture forth as a veteran shaman. As there’s no explicit levels, player strict power should have plateaued in their first game. As each new game powers up all foes and encounters (capturable spirits & new gear somewhat reflecting), players need to play smarter.

Pokemon could have really benefitted from a new game+ / full power run where team compositions could have been really tested. Why go to lvl 100 if most content needed at max level 50?

## Accolades
Capture your first spirit “First Capture”
Field [the maximum number] of spirits at once “Full Team”
Shaman Plus – beat new game+
Ceaser – reach new game IV
Ultra Codex – beat new game X

## Shaman Skills
Scroll Writing – making scrolls from raw material
Exorcism – getting rid of spirits from possessed items / beings, often starting a fight to destroy / force a spirit to flee from the entity they had possessed
Cleansing / Beckoning – creating spirit free places for normal folk or encouraging spirits to take roost
Potion Making – Inc the consumables for the above. 
Spirit Concordance – dictates the number and power of summonable spirits at any given time.

## Settlements, Campfires and Zones
Settlements, as expected. 

Campfires, small safe locations with dynamic NPC populations. 

Safe Zones are simply areas where wild spirit encounter chance is zero while in non-settlement regions. 

Danger Zones are areas where encounters can happen in “safe” areas. Tall Grass, but not obviously. 
