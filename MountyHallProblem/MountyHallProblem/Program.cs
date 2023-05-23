

using MountyHallProblem;

Console.WriteLine("Mounty Hall!");
Random random = new Random();

Console.WriteLine("initial pick door out of 1,2,3: ");
int initalPickDoor=int.Parse(Console.ReadLine());

Console.WriteLine("stay-0, switch-1: ");
Choose strategy = int.Parse(Console.ReadLine()) == 0 ? Choose.STAY : Choose.SWITCH;

Console.WriteLine("no of plays: ");
int NoOfSimulations = int.Parse(Console.ReadLine());

int totalPlays = NoOfSimulations;
int winCount = 0;

for (int i = 0; i < NoOfSimulations;i++){
    bool result = PlayMontyHall(random, initalPickDoor, strategy);
    if (result) {
        winCount++;
    }
    Console.WriteLine(result == true ? "WIN" : "loose");
}

int lcount = NoOfSimulations - winCount;
Console.WriteLine($"Totals wins: {winCount}");
Console.WriteLine($"Totals loose: {lcount}");
Console.WriteLine($"Totals wins%: {((double)winCount / (double)totalPlays)*100}%");
Console.WriteLine($"Totals loose%: {((double)lcount / (double)totalPlays)*100}%");

static bool PlayMontyHall(Random random, int initialPickedDoor,Choose strategy)
{
    int winningDoor=random.Next(3);
    int initalPick = initialPickedDoor - 1;

    //reveal
    //int revealDoor = winningDoor;
    //if (initialPickedDoor == winningDoor)
    //{
    //    while (revealDoor == winningDoor)
    //        revealDoor = random.Next(0, 3);
    //}
    //else
    //{
    //    var doors = new int[] { 0, 1, 2 };
    //    revealDoor = doors.FirstOrDefault(d => d != initalPick && d != winningDoor);
    //}

    //remaining door
    int remainingDoor = winningDoor;
    if (initalPick == winningDoor)
    {
        while (remainingDoor == winningDoor)
            remainingDoor = random.Next(0, 3);
    }

    //strategy
    if (strategy == Choose.STAY)
    {
        return winningDoor == initalPick;
    }
    else
    {
        return winningDoor == remainingDoor;
    }

}