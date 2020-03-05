using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{
	class rabbit{
		bool male = true;
		
		public rabbit(){
			male = true;
		}
	}
	
	class wolf{
		public bool male;
		public int saturation;
		
		public wolf(){
			male = false;
			saturation = 100;
		}
		
		static public void create(){
			Random rand = new Random();
			//if(rand.Next(101) > 50) male = true;
		}
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
				wolfs[i].saturation -= 10;
				
				if(wolfs[i].saturation < 60) {
					Random rand = new Random();
					
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
            int a = 0;
            int b = world.getstatus(wolfs, rabbits, out a);
            Console.WriteLine(a + ", " + b);
        }
    }
}