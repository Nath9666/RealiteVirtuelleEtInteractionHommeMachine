# TD Analyse documentaire 

<img src="https://charte.efrei.fr/wp-content/uploads/2022/07/LOGO_EFREI_WEB_bleu.png" width="200px"/>

Vous retrouverez dans ce document les réponses aux questions posées dans le TD d'analyse documentaire.
Ce document a été redigée par **Nathan Morel**.

## Article 1

« Efficient Physics-Based Implementation for Realistic Hand-Object Interaction in Virtual Reality »

### Q1 Objectif de l'article

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Quel est l'objectif principal de cet article ?
</div>

L'objectif principal de cet article est de proposer une méthode efficace basée sur la physique pour une interaction réaliste entre la main et l'objet dans les environnements de réalité virtuelle. Cette méthode est basée sur le modèle de friction de Coulomb, et les auteurs montrent comment l'implémenter efficacement dans un moteur VR standard pour une performance en temps réel. Ce modèle permet une simulation très convaincante de nombreux types d'actions telles que pousser, tirer, saisir, ou même des manipulations dextres comme faire tourner des objets entre les doigts sans restrictions sur les formes des objets ou les poses de la main.

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
D'après  vous,  quelles  seraient  les  applications  susceptibles  d'être  améliorées  en  utilisant  la modalité d’interaction proposée dans cet article ?
</div>

La modalité d'interaction proposée dans cet article, qui est une méthode physique efficace pour l'interaction réaliste main-objet dans les environnements de réalité virtuelle, pourrait améliorer plusieurs types d'applications :

1. Jeux en réalité virtuelle : Cette méthode pourrait rendre les interactions dans les jeux VR beaucoup plus réalistes et immersives, permettant aux joueurs de manipuler des objets de manière plus naturelle et intuitive.

2. Formation et simulation : Que ce soit pour la formation médicale, la formation militaire ou la formation industrielle, cette méthode pourrait permettre des simulations plus précises et réalistes.

3. Conception et modélisation 3D : Les designers et les architectes pourraient utiliser cette méthode pour manipuler et modifier les modèles 3D de manière plus intuitive.

4. Réhabilitation et thérapie physique : Dans les applications de santé, cette méthode pourrait être utilisée pour créer des exercices de réhabilitation plus engageants et efficaces.

5. Interfaces utilisateur en réalité augmentée : Cette méthode pourrait améliorer l'interaction avec les interfaces utilisateur en réalité augmentée, rendant ces interfaces plus naturelles et intuitives à utiliser.

### Q2 Etat de l'art

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Comment  se  positionnent  les  auteurs  par  rapports  aux  travaux  de  recherche  cités  dans  leur article
</div>

Les auteurs de cet article se positionnent en tant que chercheurs innovants dans le domaine de l'interaction main-objet en réalité virtuelle. Ils reconnaissent les travaux de recherche existants, mais soulignent les limitations de ces méthodes, notamment en termes de complexité, de performance en temps réel et de réalisme des interactions.

Ils proposent une nouvelle méthode basée sur le modèle de friction de Coulomb, qui, selon eux, offre un bon compromis entre réalisme et performance. Ils argumentent que leur méthode permet des interactions plus complexes que les méthodes existantes, comme pousser, tirer, laisser glisser un objet le long de la main, ou même faire tourner un objet entre deux doigts.

### Q3 Implentation

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Donner en une quinzaine de lignes (max) les détails de l’implémentation de la solution proposée par les auteurs
</div>

Les auteurs proposent une méthode basée sur la physique pour une interaction réaliste entre la main et l'objet dans les environnements de réalité virtuelle. Leur méthode utilise le modèle de friction de Coulomb pour simuler les forces que l'utilisateur applique aux objets en fonction de la pose 3D et du mouvement de sa main. Ils commencent par estimer la pose 3D de la main à l'aide du dispositif Leap Motion. En utilisant un modèle 3D simplifié de la main, ils détectent les intersections entre cette main et les objets virtuels. À partir de ces intersections, ils définissent des points de contact entre l'objet virtuel et un modèle de main virtuel. Ils appliquent ensuite le modèle de friction de Coulomb à ces points de contact, en tenant compte de la force appliquée par l'utilisateur et des paramètres de friction des matériaux des objets pour calculer les forces finales. Ces forces sont ensuite introduites dans un moteur physique comme PhysX, qui simule le mouvement des objets.

### Q4 Résultats experimentaux

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Décrire  brièvement  l'expérience  mise  en  place  pour évaluer  les  performances  de  la  solution proposée
</div>

Les auteurs ont mis en place une expérience pour évaluer les performances de leur solution. Ils ont demandé à des utilisateurs de réaliser différentes tâches d'interaction main-objet dans un environnement de réalité virtuelle. Les tâches comprenaient des actions telles que pousser, tirer, saisir, laisser glisser un objet le long de la main, ou faire tourner un objet entre deux doigts. Les utilisateurs ont été invités à évaluer la qualité de l'interaction en termes de réalisme, de fluidité et de facilité d'utilisation. Les auteurs ont mesuré les performances de leur solution en termes de temps de calcul, de fréquence d'images et de latence.

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Sur quels critères et quels documents classiques en RV les auteurs se basent-ils pour effectuer leur expérimentation ?
</div>

Les auteurs se basent sur les critères suivants pour effectuer leur expérimentation :

1. Le modèle de friction de Coulomb pour simuler les forces appliquées aux objets.
2. Un modèle 3D simplifié de la main pour détecter les intersections avec les objets virtuels.
3. Une étude pilote pour évaluer la perception de réalisme et la diversité des interactions.
4. L'évaluation de la complexité computationnelle de leur méthode.

Ils se basent sur des documents classiques en RV qui traitent de l'interaction en réalité virtuelle, de l'interaction homme-machine, de la modélisation basée sur la physique, et de la capture précise de la pose 3D des mains.

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Quelles sont les données recueillies avant/au cours de/après l'expérience ?
</div>

Les auteurs ont commencé par collecter des données sur la pose 3D de la main en utilisant le dispositif Leap Motion avant l'expérience. Pendant l'expérience, ils ont observé et enregistré les interactions entre la main et l'objet, y compris les forces appliquées, les mouvements de la main et les collisions avec les objets virtuels. Enfin, après l'expérience, ils ont recueilli des informations sur la perception des utilisateurs concernant le réalisme, la fluidité et la facilité d'utilisation de l'interaction.

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Quels outils statistiques sont-ils utilisés pour analyser les données issues de l'expérimentation ?
</div>

Dans leur analyse des données issues de l'expérimentation, les auteurs ont fait appel à divers outils statistiques. Ils ont utilisé des tests de normalité, en particulier le test de Shapiro-Wilk, pour vérifier la distribution des données. Ils ont également utilisé des tests de corrélation pour examiner les relations entre différentes variables.

En plus de cela, ils ont effectué des tests de comparaison de moyennes, comme l'ANOVA, pour identifier les différences significatives entre les groupes. Enfin, ils ont utilisé des tests de performance, tels que le temps de calcul, la fréquence d'images et la latence, pour évaluer l'efficacité de leurs méthodes.

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Donner les principaux résultats obtenus à l'issue de l'expérience
</div>

Les principaux résultats obtenus à l'issue de l'expérience sont les suivants :
- Les utilisateurs ont évalué positivement la qualité de l'interaction en termes de réalisme, de fluidité et de facilité d'utilisation.
- La méthode proposée a montré des performances en temps réel, avec des fréquences d'images élevées et une latence faible.
- Les utilisateurs ont pu réaliser des interactions complexes telles que pousser, tirer, saisir, laisser glisser un objet le long de la main, ou faire tourner un objet entre deux doigts.
- La méthode a montré une bonne robustesse et une grande variété d'interactions possibles, sans restrictions sur les formes des objets ou les poses de la main.

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Quelles sont les pistes d’amélioration proposées par les auteurs.
</div>

Les auteurs proposent plusieurs pistes d'amélioration pour leur travail. Tout d'abord, ils envisagent d'intégrer des modèles de friction plus complexes que le modèle de Coulomb qu'ils ont utilisé, tout en prenant soin de choisir des modèles qui ne compromettent pas la performance de calcul. De plus, ils sont intéressés par l'exploration des simulations en temps réel de corps mous, par exemple à travers des simulations basées sur des particules. Ils croient que leur travail fournira une base solide pour le développement de l'interaction non contrainte entre la main et l'objet dans les environnements de réalité virtuelle.

## Article 2

"Estimating  Cybersickness  of  Simulated  Motion  Using  the  Simulator  Sickness  Questionnaire  (SSQ):  A Controlled Study » 

Le but de cette étude est de déterminer quels symptômes du mal du simulateur sont associés avec le mouvement simulé. Pour se faire, les réponses au questionnaire (SSQ) pour un état de référence et un état expérimental ont été analysées puis comparées.

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Expliquer le protocole expérimental mis en place par les auteurs ainsi que les résultats obtenus 
</div>

L'étude vise à déterminer quels symptômes de cybersickness sont associés à la simulation de mouvement dans les environnements de réalité virtuelle (VRE). Les chercheurs utilisent le Simulator Sickness Questionnaire (SSQ) pour comparer les réponses entre une condition de contrôle et une condition expérimentale.

__Méthodologie__
- **Participants** : 28 étudiants (10 femmes, 18 hommes) de l'Université Macquarie, âgés de 18 à 30 ans, en bonne santé et ayant une vision normale ou corrigée. Ils étaient novices en matière de VRE.
- **Conditions expérimentales** :
  - **Contrôle** : vol doux au-dessus de collines enneigées.
  - **Expérimental** : trajet en montagnes russes virtuelles avec des mouvements rapides et des tunnels sinueux.
- **Appareils** : écran incurvé avec des projecteurs et des lunettes à obturateurs stéréo.
- **Procédure** : chaque participant a été exposé aux deux conditions pendant six minutes chacune. Des questionnaires SSQ ont été administrés après chaque condition.

__Résultats__
Les résultats montrent des augmentations significatives des symptômes de cybersickness dans la condition de simulation de mouvement élevée par rapport à la condition de contrôle :
- **Symptômes significatifs** : inconfort général, fatigue, maux de tête, fatigue oculaire, difficulté à focaliser les yeux, transpiration accrue, nausée, difficulté à se concentrer, conscience de l'estomac, vision floue.
- **Symptômes non significatifs** : salivation accrue, vertiges (yeux ouverts ou fermés), vertige, rots, sensation de tête pleine.

__Discussion__
Les résultats indiquent que 10 des 16 symptômes associés à la cybersickness augmentent significativement avec la simulation de mouvement. Les symptômes liés à la vision et à la nausée sont particulièrement touchés, tandis que ceux liés à l'activité gastrique et vestibulaire ne montrent pas d'augmentation significative. Ces résultats suggèrent que la cybersickness dans les VRE est principalement médiée par la perception visuelle et cognitive plutôt que par une activation vestibulaire réelle.

__Conclusion__
L'étude démontre que l'augmentation de la simulation de mouvement dans les VRE entraîne une augmentation significative des symptômes de cybersickness. Les résultats soulignent l'importance de contrôler les conditions expérimentales pour mieux comprendre les mécanismes sous-jacents à la cybersickness et pour développer des moyens de prévention efficaces.

## Article 3

« Being there again – Presence in real and virtual environments and its relation to usability and userexperience using a mobile navigation task » 

Dans  cette  étude  les  auteurs  comparent  différents  environnements  réels  et  virtuels  et  évaluent l’utilisabilité et l’expérience utilisateurs à l’aide de plusieurs questionnaires.

<div style="padding: 10px; border-radius:10px; color:#8dcbf0">
Expliquer  :  les  expérimentations  mises  en  place,  les  questionnaires  utilisés,  les  résultats  de l’études
</div>

__Expérimentations mises en place__

L'étude menée par Jennifer Brade et ses collègues visait à comparer la présence, l'utilisabilité et l'expérience utilisateur entre des environnements réels et virtuels. Ils ont utilisé une tâche de navigation mobile impliquant un jeu de géocaching dans deux contextes différents : 
1. Un environnement réel situé dans le centre-ville de Chemnitz, en Allemagne.
2. Un environnement virtuel immersif créé dans une CAVE (Cave Automatic Virtual Environment).

Les participants étaient répartis en deux groupes (30 participants par groupe) pour effectuer la tâche de navigation dans l'un des deux environnements.

__Questionnaires utilisés__

Pour évaluer les différentes dimensions de l'étude, plusieurs questionnaires validés ont été utilisés :

1. **ITC-SOPI (Independent Television Commission Sense of Presence Inventory)** : Ce questionnaire est largement utilisé pour mesurer la présence perçue des utilisateurs dans les environnements virtuels. Il comporte plusieurs échelles pour évaluer des aspects tels que l'engagement, le sentiment de présence physique, l'écologie de la validité, et les effets négatifs.

2. **SUS (System Usability Scale)** : Utilisé pour mesurer l'utilisabilité, ce questionnaire fournit une évaluation rapide de la facilité d'utilisation d'un système.

3. **AttrakDiff** : Ce questionnaire est utilisé pour évaluer l'expérience utilisateur, notamment la qualité hédonique (le plaisir et l'attractivité) et la qualité pragmatique (l'utilité pratique).

__Résultats de l'étude__

Les résultats ont montré des différences significatives entre les environnements réels et virtuels sur plusieurs aspects :

1. **Présence** :
   - L'environnement réel a démontré une validité écologique significativement plus élevée, ce qui signifie que les participants ont trouvé l'environnement réel plus représentatif d'une situation de la vie réelle.
   - L'environnement virtuel a obtenu des scores plus élevés pour l'engagement et les effets négatifs, indiquant que les participants étaient plus absorbés par l'expérience mais aussi plus susceptibles de ressentir des effets négatifs comme la désorientation ou l'inconfort.

2. **Utilisabilité** :
   - Des différences significatives ont été observées entre les deux environnements, avec l'environnement réel offrant une meilleure utilisabilité perçue par les participants.

3. **Expérience utilisateur** :
   - L'environnement virtuel a montré des valeurs significativement plus élevées pour la qualité hédonique, ce qui signifie que les participants ont trouvé l'environnement virtuel plus agréable et esthétiquement plaisant.
   - L'environnement réel, en revanche, a obtenu des scores plus élevés pour la qualité pragmatique, indiquant une meilleure perception de l'utilité pratique.

__Conclusion__

L'étude suggère que les environnements virtuels peuvent servir d'alternatives viables aux environnements réels pour les études d'expérience utilisateur, à condition que le sentiment de présence soit suffisamment fort. Cependant, les chercheurs doivent tenir compte des influences potentielles de la présence sur l'utilisabilité et l'expérience utilisateur lorsqu'ils interprètent les résultats. En fin de compte, les environnements réels restent supérieurs en termes de validité écologique et de qualité pragmatique, tandis que les environnements virtuels excellaient dans l'engagement et la qualité hédonique.