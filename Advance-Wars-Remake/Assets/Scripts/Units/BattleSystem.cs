﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleSystem : MonoBehaviour {

	private static Dictionary<Type, Dictionary<Type, int>> battle;

	// Use this for initialization
	void Start () {
		battle = new Dictionary<Type, Dictionary<Type, int>>();
	}

	// Update is called once per frame
	void Update () {
	}

	public static bool attackable(Unit unit1, Unit unit2) {
		if (battle[unit1.GetType()][unit2.GetType()] == 0) {
			return false;
		}
		else if (unit1.GetType() == typeof(Infantry) ||
		unit1.GetType() == typeof(Mech) || unit1.GetType() == typeof(Bike) ||
		unit1.GetType() == typeof(Recon) || unit1.GetType() == typeof(Flare) ||
		unit1.GetType() == typeof(Tank) || unit1.GetType() == typeof(MediumTank) ||
		unit1.GetType() == typeof(WarTank) || unit1.GetType() == typeof(Carrier)) {
			return true;
		}
		else if(unit1.getAmmo() == 0) {
			return false;
		}
		else {
			return true;
		}
	}
	private void dictInit() {
		Dictionary<Type, int> dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),55);
		dict.Add(typeof(Mech),45);
		dict.Add(typeof(Bike),45);
		dict.Add(typeof(Recon),12);
		dict.Add(typeof(Flare),10);
		dict.Add(typeof(AntiAir),3);
		dict.Add(typeof(Tank),5);
		dict.Add(typeof(MediumTank),5);
		dict.Add(typeof(WarTank),1);
		dict.Add(typeof(Artillery),10);
		dict.Add(typeof(AntiTank),30);
		dict.Add(typeof(Rocket),20);
		dict.Add(typeof(Missile),20);
		dict.Add(typeof(Rig),14);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),8);
		dict.Add(typeof(TCopter),30);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Infantry),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),65);
		dict.Add(typeof(Mech),55);
		dict.Add(typeof(Bike),55);
		dict.Add(typeof(Recon),85);
		dict.Add(typeof(Flare),80);
		dict.Add(typeof(AntiAir),55);
		dict.Add(typeof(Tank),55);
		dict.Add(typeof(MediumTank),25);
		dict.Add(typeof(WarTank),15);
		dict.Add(typeof(Artillery),70);
		dict.Add(typeof(AntiTank),55);
		dict.Add(typeof(Rocket),85);
		dict.Add(typeof(Missile),85);
		dict.Add(typeof(Rig),75);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),12);
		dict.Add(typeof(TCopter),35);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Mech),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),65);
		dict.Add(typeof(Mech),55);
		dict.Add(typeof(Bike),55);
		dict.Add(typeof(Recon),18);
		dict.Add(typeof(Flare),15);
		dict.Add(typeof(AntiAir),5);
		dict.Add(typeof(Tank),8);
		dict.Add(typeof(MediumTank),5);
		dict.Add(typeof(WarTank),1);
		dict.Add(typeof(Artillery),15);
		dict.Add(typeof(AntiTank),35);
		dict.Add(typeof(Rocket),35);
		dict.Add(typeof(Missile),35);
		dict.Add(typeof(Rig),20);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),12);
		dict.Add(typeof(TCopter),35);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Bike),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),75);
		dict.Add(typeof(Mech),65);
		dict.Add(typeof(Bike),65);
		dict.Add(typeof(Recon),35);
		dict.Add(typeof(Flare),30);
		dict.Add(typeof(AntiAir),8);
		dict.Add(typeof(Tank),8);
		dict.Add(typeof(MediumTank),5);
		dict.Add(typeof(WarTank),1);
		dict.Add(typeof(Artillery),45);
		dict.Add(typeof(AntiTank),15);
		dict.Add(typeof(Rocket),55);
		dict.Add(typeof(Missile),55);
		dict.Add(typeof(Rig),45);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),18);
		dict.Add(typeof(TCopter),35);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Recon),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),80);
		dict.Add(typeof(Mech),70);
		dict.Add(typeof(Bike),70);
		dict.Add(typeof(Recon),60);
		dict.Add(typeof(Flare),50);
		dict.Add(typeof(AntiAir),45);
		dict.Add(typeof(Tank),10);
		dict.Add(typeof(MediumTank),5);
		dict.Add(typeof(WarTank),1);
		dict.Add(typeof(Artillery),45);
		dict.Add(typeof(AntiTank),15);
		dict.Add(typeof(Rocket),55);
		dict.Add(typeof(Missile),55);
		dict.Add(typeof(Rig),45);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),18);
		dict.Add(typeof(TCopter),35);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Flare),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),105);
		dict.Add(typeof(Mech),105);
		dict.Add(typeof(Bike),105);
		dict.Add(typeof(Recon),60);
		dict.Add(typeof(Flare),50);
		dict.Add(typeof(AntiAir),45);
		dict.Add(typeof(Tank),15);
		dict.Add(typeof(MediumTank),10);
		dict.Add(typeof(WarTank),1);
		dict.Add(typeof(Artillery),50);
		dict.Add(typeof(AntiTank),15);
		dict.Add(typeof(Rocket),55);
		dict.Add(typeof(Missile),55);
		dict.Add(typeof(Rig),50);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),70);
		dict.Add(typeof(Bomber),70);
		dict.Add(typeof(Duster),75);
		dict.Add(typeof(BCopter),105);
		dict.Add(typeof(TCopter),120);
		dict.Add(typeof(SeaPlane),75);
		battle.Add(typeof(AntiAir),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),75);
		dict.Add(typeof(Mech),70);
		dict.Add(typeof(Bike),70);
		dict.Add(typeof(Recon),85);
		dict.Add(typeof(Flare),80);
		dict.Add(typeof(AntiAir),75);
		dict.Add(typeof(Tank),55);
		dict.Add(typeof(MediumTank),35);
		dict.Add(typeof(WarTank),20);
		dict.Add(typeof(Artillery),70);
		dict.Add(typeof(AntiTank),30);
		dict.Add(typeof(Rocket),85);
		dict.Add(typeof(Missile),85);
		dict.Add(typeof(Rig),75);
		dict.Add(typeof(Battleship),8);
		dict.Add(typeof(Carrier),8);
		dict.Add(typeof(Submarine),9);
		dict.Add(typeof(Cruiser),9);
		dict.Add(typeof(GunBoat),55);
		dict.Add(typeof(Lander),18);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),18);
		dict.Add(typeof(TCopter),35);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Tank),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),90);
		dict.Add(typeof(Mech),80);
		dict.Add(typeof(Bike),80);
		dict.Add(typeof(Recon),95);
		dict.Add(typeof(Flare),90);
		dict.Add(typeof(AntiAir),90);
		dict.Add(typeof(Tank),70);
		dict.Add(typeof(MediumTank),55);
		dict.Add(typeof(WarTank),35);
		dict.Add(typeof(Artillery),85);
		dict.Add(typeof(AntiTank),35);
		dict.Add(typeof(Rocket),90);
		dict.Add(typeof(Missile),90);
		dict.Add(typeof(Rig),90);
		dict.Add(typeof(Battleship),10);
		dict.Add(typeof(Carrier),10);
		dict.Add(typeof(Submarine),12);
		dict.Add(typeof(Cruiser),12);
		dict.Add(typeof(GunBoat),55);
		dict.Add(typeof(Lander),22);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),24);
		dict.Add(typeof(TCopter),40);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(MediumTank),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),105);
		dict.Add(typeof(Mech),95);
		dict.Add(typeof(Bike),95);
		dict.Add(typeof(Recon),105);
		dict.Add(typeof(Flare),105);
		dict.Add(typeof(AntiAir),105);
		dict.Add(typeof(Tank),85);
		dict.Add(typeof(MediumTank),75);
		dict.Add(typeof(WarTank),55);
		dict.Add(typeof(Artillery),105);
		dict.Add(typeof(AntiTank),40);
		dict.Add(typeof(Rocket),105);
		dict.Add(typeof(Missile),105);
		dict.Add(typeof(Rig),105);
		dict.Add(typeof(Battleship),12);
		dict.Add(typeof(Carrier),12);
		dict.Add(typeof(Submarine),14);
		dict.Add(typeof(Cruiser),14);
		dict.Add(typeof(GunBoat),65);
		dict.Add(typeof(Lander),28);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(BCopter),35);
		dict.Add(typeof(TCopter),45);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(WarTank),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),75);
		dict.Add(typeof(Mech),65);
		dict.Add(typeof(Bike),65);
		dict.Add(typeof(Recon),75);
		dict.Add(typeof(Flare),75);
		dict.Add(typeof(AntiAir),75);
		dict.Add(typeof(Tank),75);
		dict.Add(typeof(MediumTank),65);
		dict.Add(typeof(WarTank),55);
		dict.Add(typeof(Artillery),65);
		dict.Add(typeof(AntiTank),55);
		dict.Add(typeof(Rocket),70);
		dict.Add(typeof(Missile),70);
		dict.Add(typeof(Rig),65);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),00);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),45);
		dict.Add(typeof(TCopter),55);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(AntiTank),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),95);
		dict.Add(typeof(Mech),90);
		dict.Add(typeof(Bike),90);
		dict.Add(typeof(Recon),90);
		dict.Add(typeof(Flare),85);
		dict.Add(typeof(AntiAir),75);
		dict.Add(typeof(Tank),70);
		dict.Add(typeof(MediumTank),55);
		dict.Add(typeof(WarTank),45);
		dict.Add(typeof(Artillery),80);
		dict.Add(typeof(AntiTank),65);
		dict.Add(typeof(Rocket),85);
		dict.Add(typeof(Missile),85);
		dict.Add(typeof(Rig),80);
		dict.Add(typeof(Battleship),55);
		dict.Add(typeof(Carrier),55);
		dict.Add(typeof(Submarine),65);
		dict.Add(typeof(Cruiser),65);
		dict.Add(typeof(GunBoat),105);
		dict.Add(typeof(Lander),75);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),0);
		dict.Add(typeof(TCopter),0);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Rocket),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),0);
		dict.Add(typeof(Mech),0);
		dict.Add(typeof(Bike),0);
		dict.Add(typeof(Recon),0);
		dict.Add(typeof(Flare),0);
		dict.Add(typeof(AntiAir),0);
		dict.Add(typeof(Tank),0);
		dict.Add(typeof(MediumTank),0);
		dict.Add(typeof(WarTank),0);
		dict.Add(typeof(Artillery),0);
		dict.Add(typeof(AntiTank),0);
		dict.Add(typeof(Rocket),0);
		dict.Add(typeof(Missile),0);
		dict.Add(typeof(Rig),0);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),100);
		dict.Add(typeof(Bomber),100);
		dict.Add(typeof(Duster),100);
		dict.Add(typeof(BCopter),120);
		dict.Add(typeof(TCopter),120);
		dict.Add(typeof(SeaPlane),100);
		battle.Add(typeof(Missile),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),75);
		dict.Add(typeof(Mech),70);
		dict.Add(typeof(Bike),70);
		dict.Add(typeof(Recon),70);
		dict.Add(typeof(Flare),70);
		dict.Add(typeof(AntiAir),65);
		dict.Add(typeof(Tank),65);
		dict.Add(typeof(MediumTank),50);
		dict.Add(typeof(WarTank),40);
		dict.Add(typeof(Artillery),70);
		dict.Add(typeof(AntiTank),55);
		dict.Add(typeof(Rocket),75);
		dict.Add(typeof(Missile),75);
		dict.Add(typeof(Rig),65);
		dict.Add(typeof(Battleship),45);
		dict.Add(typeof(Carrier),50);
		dict.Add(typeof(Submarine),65);
		dict.Add(typeof(Cruiser),65);
		dict.Add(typeof(GunBoat),95);
		dict.Add(typeof(Lander),75);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),0);
		dict.Add(typeof(TCopter),0);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Battleship),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),0);
		dict.Add(typeof(Mech),0);
		dict.Add(typeof(Bike),0);
		dict.Add(typeof(Recon),0);
		dict.Add(typeof(Flare),0);
		dict.Add(typeof(AntiAir),0);
		dict.Add(typeof(Tank),0);
		dict.Add(typeof(MediumTank),0);
		dict.Add(typeof(WarTank),0);
		dict.Add(typeof(Artillery),0);
		dict.Add(typeof(AntiTank),0);
		dict.Add(typeof(Rocket),0);
		dict.Add(typeof(Missile),0);
		dict.Add(typeof(Rig),0);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),35);
		dict.Add(typeof(Bomber),35);
		dict.Add(typeof(Duster),40);
		dict.Add(typeof(BCopter),45);
		dict.Add(typeof(TCopter),55);
		dict.Add(typeof(SeaPlane),40);
		battle.Add(typeof(Carrier),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),0);
		dict.Add(typeof(Mech),0);
		dict.Add(typeof(Bike),0);
		dict.Add(typeof(Recon),0);
		dict.Add(typeof(Flare),0);
		dict.Add(typeof(AntiAir),0);
		dict.Add(typeof(Tank),0);
		dict.Add(typeof(MediumTank),0);
		dict.Add(typeof(WarTank),0);
		dict.Add(typeof(Artillery),0);
		dict.Add(typeof(AntiTank),0);
		dict.Add(typeof(Rocket),0);
		dict.Add(typeof(Missile),0);
		dict.Add(typeof(Rig),0);
		dict.Add(typeof(Battleship),80);
		dict.Add(typeof(Carrier),110);
		dict.Add(typeof(Submarine),55);
		dict.Add(typeof(Cruiser),20);
		dict.Add(typeof(GunBoat),120);
		dict.Add(typeof(Lander),85);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),0);
		dict.Add(typeof(TCopter),0);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Submarine),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),0);
		dict.Add(typeof(Mech),0);
		dict.Add(typeof(Bike),0);
		dict.Add(typeof(Recon),0);
		dict.Add(typeof(Flare),0);
		dict.Add(typeof(AntiAir),0);
		dict.Add(typeof(Tank),0);
		dict.Add(typeof(MediumTank),0);
		dict.Add(typeof(WarTank),0);
		dict.Add(typeof(Artillery),0);
		dict.Add(typeof(AntiTank),0);
		dict.Add(typeof(Rocket),0);
		dict.Add(typeof(Missile),0);
		dict.Add(typeof(Rig),0);
		dict.Add(typeof(Battleship),38);
		dict.Add(typeof(Carrier),38);
		dict.Add(typeof(Submarine),95);
		dict.Add(typeof(Cruiser),28);
		dict.Add(typeof(GunBoat),85);
		dict.Add(typeof(Lander),40);
		dict.Add(typeof(Fighter),105);
		dict.Add(typeof(Bomber),105);
		dict.Add(typeof(Duster),105);
		dict.Add(typeof(BCopter),120);
		dict.Add(typeof(TCopter),120);
		dict.Add(typeof(SeaPlane),105);
		battle.Add(typeof(Cruiser),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),0);
		dict.Add(typeof(Mech),0);
		dict.Add(typeof(Bike),0);
		dict.Add(typeof(Recon),0);
		dict.Add(typeof(Flare),0);
		dict.Add(typeof(AntiAir),0);
		dict.Add(typeof(Tank),0);
		dict.Add(typeof(MediumTank),0);
		dict.Add(typeof(WarTank),0);
		dict.Add(typeof(Artillery),0);
		dict.Add(typeof(AntiTank),0);
		dict.Add(typeof(Rocket),0);
		dict.Add(typeof(Missile),0);
		dict.Add(typeof(Rig),0);
		dict.Add(typeof(Battleship),40);
		dict.Add(typeof(Carrier),40);
		dict.Add(typeof(Submarine),40);
		dict.Add(typeof(Cruiser),40);
		dict.Add(typeof(GunBoat),75);
		dict.Add(typeof(Lander),55);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),0);
		dict.Add(typeof(TCopter),0);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(GunBoat),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),0);
		dict.Add(typeof(Mech),0);
		dict.Add(typeof(Bike),0);
		dict.Add(typeof(Recon),0);
		dict.Add(typeof(Flare),0);
		dict.Add(typeof(AntiAir),0);
		dict.Add(typeof(Tank),0);
		dict.Add(typeof(MediumTank),0);
		dict.Add(typeof(WarTank),0);
		dict.Add(typeof(Artillery),0);
		dict.Add(typeof(AntiTank),0);
		dict.Add(typeof(Rocket),0);
		dict.Add(typeof(Missile),0);
		dict.Add(typeof(Rig),0);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),0);
		dict.Add(typeof(TCopter),0);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Lander),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),0);
		dict.Add(typeof(Mech),0);
		dict.Add(typeof(Bike),0);
		dict.Add(typeof(Recon),0);
		dict.Add(typeof(Flare),0);
		dict.Add(typeof(AntiAir),0);
		dict.Add(typeof(Tank),0);
		dict.Add(typeof(MediumTank),0);
		dict.Add(typeof(WarTank),0);
		dict.Add(typeof(Artillery),0);
		dict.Add(typeof(AntiTank),0);
		dict.Add(typeof(Rocket),0);
		dict.Add(typeof(Missile),0);
		dict.Add(typeof(Rig),0);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),55);
		dict.Add(typeof(Bomber),65);
		dict.Add(typeof(Duster),80);
		dict.Add(typeof(BCopter),120);
		dict.Add(typeof(TCopter),120);
		dict.Add(typeof(SeaPlane),65);
		battle.Add(typeof(Fighter),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),115);
		dict.Add(typeof(Mech),110);
		dict.Add(typeof(Bike),110);
		dict.Add(typeof(Recon),105);
		dict.Add(typeof(Flare),105);
		dict.Add(typeof(AntiAir),85);
		dict.Add(typeof(Tank),105);
		dict.Add(typeof(MediumTank),95);
		dict.Add(typeof(WarTank),75);
		dict.Add(typeof(Artillery),105);
		dict.Add(typeof(AntiTank),80);
		dict.Add(typeof(Rocket),105);
		dict.Add(typeof(Missile),95);
		dict.Add(typeof(Rig),105);
		dict.Add(typeof(Battleship),85);
		dict.Add(typeof(Carrier),85);
		dict.Add(typeof(Submarine),95);
		dict.Add(typeof(Cruiser),50);
		dict.Add(typeof(GunBoat),120);
		dict.Add(typeof(Lander),95);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),0);
		dict.Add(typeof(TCopter),0);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Bomber),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),55);
		dict.Add(typeof(Mech),45);
		dict.Add(typeof(Bike),45);
		dict.Add(typeof(Recon),18);
		dict.Add(typeof(Flare),15);
		dict.Add(typeof(AntiAir),5);
		dict.Add(typeof(Tank),8);
		dict.Add(typeof(MediumTank),5);
		dict.Add(typeof(WarTank),1);
		dict.Add(typeof(Artillery),15);
		dict.Add(typeof(AntiTank),5);
		dict.Add(typeof(Rocket),20);
		dict.Add(typeof(Missile),20);
		dict.Add(typeof(Rig),15);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),40);
		dict.Add(typeof(Bomber),45);
		dict.Add(typeof(Duster),55);
		dict.Add(typeof(BCopter),75);
		dict.Add(typeof(TCopter),90);
		dict.Add(typeof(SeaPlane),45);
		battle.Add(typeof(Duster),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),0);
		dict.Add(typeof(Mech),0);
		dict.Add(typeof(Bike),0);
		dict.Add(typeof(Recon),0);
		dict.Add(typeof(Flare),0);
		dict.Add(typeof(AntiAir),0);
		dict.Add(typeof(Tank),0);
		dict.Add(typeof(MediumTank),0);
		dict.Add(typeof(WarTank),0);
		dict.Add(typeof(Artillery),0);
		dict.Add(typeof(AntiTank),0);
		dict.Add(typeof(Rocket),0);
		dict.Add(typeof(Missile),0);
		dict.Add(typeof(Rig),0);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(BCopter),0);
		dict.Add(typeof(TCopter),0);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(TCopter),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),90);
		dict.Add(typeof(Mech),85);
		dict.Add(typeof(Bike),85);
		dict.Add(typeof(Recon),80);
		dict.Add(typeof(Flare),75);
		dict.Add(typeof(AntiAir),45);
		dict.Add(typeof(Tank),75);
		dict.Add(typeof(MediumTank),65);
		dict.Add(typeof(WarTank),55);
		dict.Add(typeof(Artillery),70);
		dict.Add(typeof(AntiTank),50);
		dict.Add(typeof(Rocket),80);
		dict.Add(typeof(Missile),70);
		dict.Add(typeof(Rig),75);
		dict.Add(typeof(Battleship),65);
		dict.Add(typeof(Carrier),65);
		dict.Add(typeof(Submarine),55);
		dict.Add(typeof(Cruiser),40);
		dict.Add(typeof(GunBoat),105);
		dict.Add(typeof(Lander),85);
		dict.Add(typeof(Fighter),45);
		dict.Add(typeof(Bomber),55);
		dict.Add(typeof(Duster),65);
		dict.Add(typeof(BCopter),85);
		dict.Add(typeof(TCopter),95);
		dict.Add(typeof(SeaPlane),55);
		battle.Add(typeof(SeaPlane),dict);
	}
}
