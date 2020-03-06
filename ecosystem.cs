using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{
	class rabbit{
		Random rand = new Random();
		public bool male;
		public bool ready;
		
		public rabbit(){
			male = (rand.Next(101) >= 50);
			ready = true;
		}
		
		
	}
	
	class wolf{
		public bool male;
		public int saturation;
		Random rand = new Random();
		
		public wolf(){
			male = (rand.Next(101) >= 0);
			saturation = rand.Next(50, 100);
		}
		
	
	class world{
		static public int getstatus(wolf[] wolfs, rabbit[] rabbits, out int wolfN){
			int rabN = 0;
			wolfN = 0;
			foreach (wolf a in wolfs){
				if(a != null) wolfN++;
			}
			foreach (rabbit b in rabbits){
				if(b != null) rabN++;
			}
			return rabN;
		}
		
		static public void generate(ref wolf[] wolfs, ref rabbit[] rabbits){
			Random rand = new Random();
			for (int i = 0; i < wolfs.Length; i++){
				if (rand.Next(101) > 60) wolfs[i] = new wolf();
			};
			
			for (int i = 0; i < rabbits.Length; i++){
				if (rand.Next(101) > 20) rabbits[i] = new rabbit();
			}
		}
		
		static public void tick(ref wolf[] wolfs, ref rabbit[] rabbits){
			for (int i = 0; i < wolfs.Length; i++){
				//wolf
				if (wolfs[i] == null) continue;
				wolfs[i].saturation -= 10;
				
				if (wolfs[i].saturation < 60) { //Food
					Random rand = new Random();
					int n = rand.Next(10);
					if(rabbits[n] != null) {
						rabbits[n] = null;
						wolfs[i].saturation += 40;
					}
				}
				
				if(wolfs[i].saturation <= 0) wolfs[i] = null;
				
				
				//rabbit
				int[] freeslots = new int[10];
				int num = 0;
				for (int b = 0; b < rabbits.Length; b++){
					if (rabbits[b] != null) {
						freeslots[num] = b;
						num++;
					}
				};
				
				foreach (rabbit a in rabbits){
					if (a == null) continue;
					if (a.male == true){
						rabbit female;
						foreach (rabbit b in rabbits){
							if (b.male) female = b;
							return;
						}
						if(female != null){
							female.ready = false;
						}
					}
				}
			}
		}
	}

    public class Ecosystem 
    {
        wolf[] wolfs = new wolf[10];
        rabbit[] rabbits = new rabbit[10];
        
        private void Main() {
        	world.generate(ref wolfs, ref rabbits);
        	
        	int a = 1;
        	int b = 1;
        	int tickN = 0;
        	
        	while (a > 0 || b > 0) {
        		tickN++;
                a = 0;
                b = world.getstatus(wolfs, rabbits, out a);
                Console.WriteLine("{0} Tick: {1} Wolfs {2} Rabbits", tickN, a, b);
                world.tick(ref wolfs, ref rabbits);
        	}
        }
    }
}}