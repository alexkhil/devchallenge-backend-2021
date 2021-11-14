using CSharpFunctionalExtensions;

namespace DevChallenge.Domain;

public class RowBoxPacker : IBoxPacker
{
    public Result<IReadOnlyList<(int x, int y)>> Pack(Sheet sheet, Box template)
    {
        var xPos = 0;
        var yPos = 0;

        var positions = new List<(int x, int y)>();

        // TODO: add coords to box
        // var newBox = Box.Create(template.Width, template.Height, template.Depth).Value;
        while ((yPos + template.TemplateWidth) > sheet.Height.Value)
        {
            if ((xPos + template.TemplateWidth) > sheet.Width.Value)
            {
                yPos += template.TemplateHeight;
                xPos = 0;
            }

            positions.Add((xPos, yPos));
            xPos += template.TemplateWidth;
        }

        return positions;
    }
}